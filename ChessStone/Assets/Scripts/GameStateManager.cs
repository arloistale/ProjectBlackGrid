using UnityEngine;
using System.Collections;
using X_UniTMX;

public class GameStateManager : Singleton<GameStateManager> {

	#region State Data
	
	
	public enum State {
		CharacterSelection,
		Battle,
		Finish,
		End
	}
	
	private State currState;
	
	
	#endregion
	
	#region Modular Data
	
	
	[SerializeField]
	private CharacterSelectionManager characterSelectionManager;
	
	[SerializeField]
	private BattleManager battleManager;
	
	
	#endregion

	#region Init


	public void Begin() {
		StartCoroutine(UpdateState());
	}


	#endregion

	#region States


	private IEnumerator UpdateState() {
		currState = State.CharacterSelection;

		while(currState != State.End) {
			switch(currState)
			{
			case State.CharacterSelection:
				yield return StartCoroutine(HandleCharacterSelection());
				break;
			case State.Battle:
				yield return StartCoroutine(HandleBattle());
				break;
			case State.Finish:
				yield return StartCoroutine(HandleFinish());
				break;
			}
		}

		End();
	}

	private IEnumerator HandleCharacterSelection() {

		characterSelectionManager.Begin();

		while(characterSelectionManager.currState != CharacterSelectionManager.State.End) {
			yield return null;
		}

		currState = State.Battle;
	}

	private IEnumerator HandleBattle() {
		battleManager.Begin();

		while(battleManager.currState != BattleManager.State.End) {
			yield return null;
		}
		
		currState = State.Finish;
	}

	private IEnumerator HandleFinish() {
		yield return new WaitForSeconds(1.0f);

		currState = State.End;
	}


	#endregion

	#region Interaction


	public void End() {
		PlayerData.Instance.lastLevel = Application.loadedLevel;
		Application.LoadLevel("Map");
	}


	#endregion
}