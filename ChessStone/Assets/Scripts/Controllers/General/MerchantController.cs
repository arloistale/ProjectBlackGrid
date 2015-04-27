using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using X_UniTMX;

public sealed class MerchantController : MonoBehaviour
{
	#region State Data


	public enum State {
		Neutral,
		Buy,
		Sell,
		End
	}
	
	private State _currState;
	public State currState {
		get { return _currState; }
	}


	#endregion

	#region Graphics Data


	[SerializeField]
	private UIHeaderCard headerCard;

	[SerializeField]
	private UICharacterCard characterCard;

	[SerializeField]
	private UIMerchantCard merchantCard;


	#endregion

	#region Game Data


	private int currPlayerSetIndex = 0;
	private int currMerchantSetIndex = 0;
	private int numMerchantSets = 0;
	private int numPlayerSets = 0;

	private MerchantData merchantData;


	#endregion

	#region Initialization


	void Start() {
		merchantCard.AddFocusCallback(characterCard.UpdateCard);
		merchantCard.AddSellCallback(OnSell);
		merchantCard.AddPurchaseCallback(OnPurchase);
	}

	public void Begin(MerchantData merchant) {
		merchantData = merchant;

		_currState = State.Buy;
		numPlayerSets = PlayerData.Instance.characterList.GetNumSets(3);
		numMerchantSets = Mathf.CeilToInt(merchantData.numItems / 3f);

		currPlayerSetIndex = 0;
		currMerchantSetIndex = 0;

		merchantCard.UpdateHeader(merchantData.name);
		merchantCard.UpdateMerchantItemCards(merchantData.TakeSet(currMerchantSetIndex, 3));
		merchantCard.UpdatePlayerItemCards(PlayerData.Instance.characterList.TakeSet(currPlayerSetIndex, 3));

		merchantCard.Show(true);
		characterCard.Show(true);
	}

	public void End() {
		_currState = State.End;
		merchantCard.Show(false);
		characterCard.Show(false);
	}


	#endregion

	#region Event Handlers


	public void OnClose() {
		End ();
	}

	public void OnBuyMode() {
		_currState = State.Buy;
		merchantCard.ShowMerchantItems(true);
		merchantCard.ShowPlayerItems(false);
	}

	public void OnSellMode() {
		_currState = State.Sell;
		merchantCard.ShowMerchantItems(false);
		merchantCard.ShowPlayerItems(true);
	}

	public void OnUp() {
		switch(currState) {
		case State.Buy:
			currMerchantSetIndex--; if(currMerchantSetIndex < 0) currMerchantSetIndex = numMerchantSets - 1;
			merchantCard.UpdateMerchantItemCards(merchantData.TakeSet(currMerchantSetIndex, 3));
			break;
		case State.Sell:
			currPlayerSetIndex--; if(currPlayerSetIndex < 0) currPlayerSetIndex = numPlayerSets - 1;
			merchantCard.UpdatePlayerItemCards(PlayerData.Instance.characterList.TakeSet(currPlayerSetIndex, 3));
			break;
		}
	}
	
	public void OnDown() {
		switch(currState) {
		case State.Buy:
			currMerchantSetIndex = (currMerchantSetIndex + 1) % numMerchantSets;
			merchantCard.UpdateMerchantItemCards(merchantData.TakeSet(currMerchantSetIndex, 3));
			break;
		case State.Sell:
			currPlayerSetIndex = (currPlayerSetIndex + 1) % numPlayerSets;
			merchantCard.UpdatePlayerItemCards(PlayerData.Instance.characterList.TakeSet(currPlayerSetIndex, 3));
			break;
		}
	}
	
	private void OnPurchase(int characterId) {
		CharacterData characterData = CharacterBuilder.Instance.GetCharacterData(characterId);
		int cost = characterData.cost;
		PlayerData.Instance.AddCoins(-cost);
		PlayerData.Instance.AddCharacter(characterId);
		numPlayerSets = PlayerData.Instance.characterList.GetNumSets(3);
		merchantCard.UpdateMerchantItemCards(merchantData.TakeSet(currMerchantSetIndex, 3));
		merchantCard.UpdatePlayerItemCards(PlayerData.Instance.characterList.TakeSet(currPlayerSetIndex, 3));
		headerCard.UpdateLabels(PlayerData.Instance.coins);
	}

	private void OnSell(int characterId) {
		CharacterData characterData = CharacterBuilder.Instance.GetCharacterData(characterId);
		int cost = characterData.cost;
		PlayerData.Instance.AddCoins(cost);
		PlayerData.Instance.DepleteCharacter(characterId);
		numPlayerSets = PlayerData.Instance.characterList.GetNumSets(3);
		merchantCard.UpdateMerchantItemCards(merchantData.TakeSet(currMerchantSetIndex, 3));
		merchantCard.UpdatePlayerItemCards(PlayerData.Instance.characterList.TakeSet(currPlayerSetIndex, 3));
		headerCard.UpdateLabels(PlayerData.Instance.coins);
	}


	#endregion
}