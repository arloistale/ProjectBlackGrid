using UnityEngine;
using System.Collections;

using SQLite4Unity3d;

public class StageData
{
	#region Data


	[PrimaryKey]
	public int id { get; set; }

	public string name { get; set; }

	public string description { get; set; }
	
	public int rewardCash { get; set; }
	
	public string mapPath { get; set; }
	
	public int objectiveId { get; set; }

	public int conversationId { get; set; }

	
	#endregion
}