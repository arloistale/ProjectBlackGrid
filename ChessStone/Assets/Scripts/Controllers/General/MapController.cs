using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class MapController : MonoBehaviour
{
	#region State Data


	private enum MapLevel {
		Nodes,
		Regions
	}

	public enum State {
		None,
		Neutral,
		End
	}
	
	private MapLevel mapLevel;

	public State currState { get; set; }


	#endregion

	#region Game Data


	[SerializeField]
	private RegionMap regionMap;

	[SerializeField]
	private NodeMap nodeMap;

	private MapNode focusStageNode;


	#endregion

	#region Graphics Data


	[SerializeField]
	private UINodeCard nodeCard;


	#endregion

	#region Controller Data


	[SerializeField]
	private MerchantController merchantController;


	#endregion

	#region Input Data


	[SerializeField]
	private RegionSelector regionSelector;

	[SerializeField]
	private NodeSelector nodeSelector;


	#endregion

	#region Initialization


	void Awake() {
		Begin();
	}

	public void Begin() {
		currState = State.Neutral;
		mapLevel = MapLevel.Regions;
		Camera.main.orthographicSize = 4f;

		nodeSelector.clickCallback = OnNodeClick;
		regionSelector.clickCallback = OnRegionClick;

		regionSelector.Begin();
	}

	public void End() {
		currState = State.End;
		nodeSelector.End();
		regionSelector.End();
	}


	#endregion

	#region Event Handlers


	private void OnRegionClick(MapRegion region) {
		ZoomIn(region);
	}

	private void OnNodeClick(MapNode node) {
		if(node.stageId != -1) {
			focusStageNode = node;
			nodeCard.UpdateCard(node);
			nodeCard.Show (true);
		} else if(node.merchantId != -1) {
			merchantController.Begin(MerchantBuilder.Instance.BuildMerchant(node.merchantId));
		}
	}

	public void OnNodeCardConfirm() {
		PlayerData.Instance.lastLevel = Application.loadedLevel;
		PlayerData.Instance.currStage = focusStageNode.stageId;
		Application.LoadLevel("Main");
	}

	public void OnNodeCardClose() {
		focusStageNode = null;
		nodeCard.Show(false);
	}
	
	
	#endregion

	#region Interaction
	

	public void ZoomIn(MapRegion focusRegion) {
		Camera.main.orthographicSize = 6.5f;
		mapLevel = MapLevel.Nodes;
		
		regionMap.Show(false);
		nodeMap.LoadRegion(focusRegion);
		
		regionSelector.End();
		nodeSelector.Begin();
	}
	
	public void ZoomOut() {
		Camera.main.orthographicSize = 4f;
		mapLevel = MapLevel.Regions;
		
		regionMap.Show(true);
		
		nodeSelector.End();
		regionSelector.Begin();
	}
	
	
	#endregion
}