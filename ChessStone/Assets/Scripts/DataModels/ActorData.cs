using UnityEngine;
using System.Collections;

using SQLite4Unity3d;

public class ActorData
{
	#region Data
	
	
	[PrimaryKey]
	public int id { get; set; }

	public string name { get; set; }

	public string imagePath { get; set; }

	public bool isPlayer { get; set; }

	
	#endregion

	#region Cached Data


	private Sprite _image;
	public Sprite image {
		get {
			if(_image == null) _image = LoadSprite(imagePath);
			
			return _image;
		}
	}


	#endregion

	#region Helpers


	public Sprite LoadSprite(string resourcePath) {
		Sprite resourceSprite = Resources.Load<Sprite>(resourcePath);
		Resources.UnloadUnusedAssets();
		if (resourceSprite != null) {
			return resourceSprite;
		} else {
			Debug.LogError("Character sprite doesn't exist at: Resources/" + resourcePath);
		}

		return null;
	}


	#endregion
}