using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using X_UniTMX;
using SimpleJSON;

/// <summary>
/// Damages the target for the amount.
/// REQUIRES: target must be a GameCharacter
/// </summary>
public class Transport : SpellEffect
{
	private GameCharacter self;

	public override void Activate(GameCharacter self, Tile target = null, SpellEffectFinishedDelegate finishedCallback = null)
	{
		// get unit adjacent tail
		// transport to target

		if(!GameMap.Instance.IsTileValid(target)) return;

		GameUnitLink tail = self.health.tail;
		this.self = self;
		List<Tile> allyTiles = GameMap.Instance.ComputeTilesInRange(tail.GetTile(), 1, IsTileAlly);
		Tile allyTile = allyTiles.FirstOrDefault();
		if(allyTile != null) {
			GameCharacter ally = (GameCharacter)allyTile.currUnit;
			ally.health.SetSize(1);
			ally.SetTile(target);
		}
	}

	private bool IsTileAlly(Tile filterTile) {
		if(filterTile.currUnit == null || filterTile.currUnit.unitType != UnitType.Character) return false;
		GameCharacter filterCharacter = (GameCharacter)filterTile.currUnit;
		return filterCharacter.owningPlayer == self.owningPlayer;
	}
}