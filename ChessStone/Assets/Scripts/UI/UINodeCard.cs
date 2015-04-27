using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UINodeCard : MonoBehaviour {

	#region Graphics Data


	[SerializeField]
	private Image portrait;
	
	[SerializeField]
	private Text nameText;
	
	[SerializeField]
	private Text nodeDescriptionText;
	
	[SerializeField]
	private Text questDescriptionText;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private CanvasGroup headerCanvasGroup;

	[SerializeField]
	private CanvasGroup bodyCanvasGroup;

	[SerializeField]
	private CanvasGroup footerCanvasGroup;

	
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
		headerCanvasGroup.alpha = 0;
		bodyCanvasGroup.alpha = 0;

		portrait.sprite = null;
		nameText.text = "";
		nodeDescriptionText.text = "";
		questDescriptionText.text = "";
	}

	public void UpdateCard(MapNode node) {
		ClearCard();

		headerCanvasGroup.alpha = 1;
		bodyCanvasGroup.alpha = 1;

		NodeDomainData domainData = node.domainData;

		UpdateHeader(domainData.icon, node.displayName, node.displayDescription);
		UpdateBody(node.displayQuestDescription);
	}

	public void UpdateHeader(Sprite icon, string name, string nodeDescription) {
		portrait.sprite = icon;
		nameText.text = name;
		nodeDescriptionText.text = nodeDescription;
	}

	public void UpdateBody(string questDescription) {
		questDescriptionText.text = questDescription;
	}

	
	#endregion
}