using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIDialogueCard : MonoBehaviour {

	#region Graphics Data


	[SerializeField]
	private Image portrait;
	
	[SerializeField]
	private Text nameText;

	[SerializeField]
	private CanvasGroup canvasGroup;
	
	[SerializeField]
	private CanvasGroup headerCanvasGroup;

	
	#endregion

	#region Initialization
	
	
	void Start() {
		ClearCard();
	}
	

	#endregion
	
	#region Interaction
	

	public void Show(bool flag) {
		canvasGroup.alpha = flag ? 1 : 0;
		canvasGroup.interactable = flag;
		canvasGroup.blocksRaycasts = flag;
	}

	public void ClearCard() {
		portrait.sprite = null;
		nameText.text = "";
	}

	public void UpdateCard(DialogEntryData dialogEntry) {
		ClearCard();

		ActorData actor = dialogEntry.actor;

		UpdateMasthead(actor.name, actor.image);
	}

	public void UpdateMasthead(string name, Sprite image) {
		portrait.sprite = image;
		nameText.text = name;
	}

	
	#endregion
}