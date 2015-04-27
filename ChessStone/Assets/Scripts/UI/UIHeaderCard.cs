using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIHeaderCard : MonoBehaviour {

	#region Graphics Data


	[SerializeField]
	private Text coinsText;

	
	#endregion

	#region Game Data


	#endregion

	#region Initialization
	
	
	void Start() {
		ClearLabels();

		UpdateLabels(PlayerData.Instance.coins);
	}
	

	#endregion
	
	#region Interaction


	public void ClearLabels() {
		coinsText.text = "";
	}

	public void UpdateLabels(int coins) {
		ClearLabels();

		coinsText.text = "" + coins;
	}

	
	#endregion
}