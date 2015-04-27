using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



using System.IO;
using System.Xml.Serialization;

public class ConversationBuilder : PersistentSingleton<ConversationBuilder>
{
	private Dictionary<int, ConversationData> _mappedConversationData = new Dictionary<int, ConversationData>();

	public ConversationData BuildConversation(int id) {
		if(!_mappedConversationData.ContainsKey(id)) {
			XmlSerializer deserializer = new XmlSerializer(typeof(ConversationData));
			//FileStream stream = new FileStream(
			ConversationData loaded = null;//(ConversationData)deserializer.Deserialize(

			_mappedConversationData.Add(loaded.id, loaded);

			return loaded;
		} else {
			return _mappedConversationData[id];
		}
		
		return null;
	}

	public ConversationData GetConversationData(int id) {
		return _mappedConversationData[id];
	}

	#region Helpers


	#endregion
}