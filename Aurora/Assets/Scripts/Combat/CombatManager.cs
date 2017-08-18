using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager> {

	// The phases of combate.
	// START_COMBATE: All functionality that is needed for combate should be done here.
	// START_TURN: Do everthing that needs to be done at the start of the turn.
	// ATTACKER: The attacker's part of the turn.
	// DEFENDER: The defender's part of the turn. The defender will be able to see what the attacker is going to do.
	// EXECUTE: All actions are done here.
	// PLAYER_WIN: The player wins.
	// PLAYER_LOSE: The player loses.
	// END_TURN: All End of turn things are done here.
	// END_COMBAT: All exti combate funciontaliy is done here.
	public enum CombatPhases
	{
		START_COMBAT = 1, 
		START_TURN = 2, 
		ATTACKER = 3,
		DEFENDER = 4, 
		EXECUTE = 5, 
		END_TURN = 6, 
		END_COMBATE = 7,
		PLAYER_WIN = 8, 
		PLAYER_LOSE = 9
	};

	protected CombatManager () {}

	public CombatPhases curPhase = CombatPhases.START_COMBAT;
	public EntitySheet[] entities; // Should be set to a size of two but I kind of what to use this for future projects.

	// Goes to the next phase ignores the PLAYER_WIN and PLAYER_LOSE phase.
	public void GotoNextPhase (CombatPhases curPhase) {
	
	}

	// Checks if the player has won or lost.
	public bool CheckWinOrLose () {
		return true;
	}

	// Runs though the logic of each phase.
	private void Update () {
		
	}
}