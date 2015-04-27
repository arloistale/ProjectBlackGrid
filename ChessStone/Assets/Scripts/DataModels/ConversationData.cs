using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Conversation")]
public class ConversationData
{
	#region Data
	
	
	[XmlAttribute("ID")]
	public int id { get; set; }

	[XmlArray("DialogEntries")]
	[XmlArrayItem("DialogEntry", typeof(DialogEntryData))]
	public List<DialogEntryData> dialogEntries { get; set; }


	#endregion

	public ConversationData() {
		dialogEntries = new List<DialogEntryData>();
	}
}