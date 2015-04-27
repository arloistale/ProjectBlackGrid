using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using X_UniTMX;

public sealed class ConversationController : MonoBehaviour
{
	#region State Data


	public enum State {
		Neutral,
		InConversation,
		End
	}
	
	private State _currState;
	public State currState {
		get { return _currState; }
	}


	#endregion

	#region Graphics Data


	[SerializeField]
	private UIDialogueCard dialogueCard;


	#endregion

	#region Game Data
	

	private ConversationData conversationData;


	#endregion

	#region Initialization
	

	void Start() {
		if(PlayerData.Instance.pendingConversation != -1) {
			ConversationData conversation = ConversationBuilder.Instance.BuildConversation(PlayerData.Instance.pendingConversation);
			Begin (conversation);
		}
	}

	public void Begin(ConversationData conversation) {
		StartCoroutine(PlayConversation(conversation));
		_currState = State.InConversation;
	}

	public void End() {
		_currState = State.End;
		dialogueCard.Show(false);
	}


	#endregion

	#region Dialogue Functions


	private IEnumerator PlayConversation(ConversationData conversation) {
		while(currState == State.InConversation) {
			/*
			dialogueCard.UpdateCard();
			dialogueCard.Show(true);
			*/
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void MoveDialogue(int id) {

	}


	#endregion

	#region Event Handlers


	public void OnClose() {
		End ();
	}


	#endregion
}