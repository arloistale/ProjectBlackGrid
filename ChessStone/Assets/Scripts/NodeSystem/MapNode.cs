using UnityEngine;
using System.Collections;

public class MapNode : MonoBehaviour
{
	public int stageId { get; set; }
	
	public int merchantId { get; set; }

	public NodeDomainData domainData { get; set; }

	public string displayName { get; set; }

	public string displayDescription { get; set; }

	public string displayQuestDescription { get; set; }
}