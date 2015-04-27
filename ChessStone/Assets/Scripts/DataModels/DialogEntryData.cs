using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("DialogEntry")]
public class DialogEntryData
{
	#region Data
	
	
	[XmlAttribute("ID")]
	public int id { get; set; }

	[XmlAttribute("IsRoot")]
	public bool isRoot { get; set; }

	[XmlIgnore]
	public string title { get; set; }

	[XmlIgnore]
	public int actorId { get; set; }

	[XmlIgnore]
	public int conversantId { get; set; }

	[XmlElement]
	public string conditionsString { get; set; }
	
	
	#endregion

	#region Cached Data


	private ActorData _actor;
	public ActorData actor {
		get {
			return _actor;
		}
	}

	public ActorData _conversant;
	public ActorData conversant {
		get {
			return _conversant; 
		}
	}


	#endregion
}