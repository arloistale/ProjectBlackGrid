using UnityEngine;
using System.Collections;

using SQLite4Unity3d;

public class NodeDomainData
{
	#region Data


	[PrimaryKey]
	public int id { get; set; }
	
	public string name { get; set; }
	
	public string description { get; set; }

	public string iconPath { get; set; }
	
	public string spritePath { get; set; }


	#endregion

	#region Cached Data


	private Sprite _sprite;
	public Sprite sprite {
		get {
			if(_sprite == null) _sprite = LoadSprite(spritePath);
			return _sprite;
		}
	}

	private Sprite _icon;
	public Sprite icon {
		get {
			if(_icon == null) _icon = LoadSprite(iconPath);
			return _icon;
		}
	}

	
	#endregion

	#region Init


	public Sprite LoadSprite(string resourcePath) {
		Sprite resourceSprite = Resources.Load<Sprite>(resourcePath);
		Resources.UnloadUnusedAssets();
		if (resourceSprite != null) {
			Debug.Log ("Loaded sprite: " + resourceSprite);
			return resourceSprite;
		} else {
			Debug.LogError("Node sprite doesn't exist at: Resources/" + resourcePath);
		}

		return null;
	}


	#endregion
}