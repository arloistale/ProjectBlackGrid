using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using X_UniTMX;
using SimpleJSON;

/// <summary>
/// Removes a tile from the map.
/// REQUIRES: target is a tile
/// </summary>
public class RemoveTile : SpellEffect
{
	public override void Activate(GameCharacter self, Tile target = null, SpellEffectFinishedDelegate finishedCallback = null)
	{
		GameMap.Instance.ReplaceTile(2, target.x, target.y);
	}
}