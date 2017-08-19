using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{

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

    protected CombatManager()
    {
    }

    public CombatPhases curPhase = CombatPhases.START_COMBAT;
    public EntitySheet[] entities;
    public bool isOver = false;
    // Should be set to a size of two but I kind of what to use this for future projects.

    private EntitySheet player;

    // Goes to the next phase ignores the PLAYER_WIN and PLAYER_LOSE phase.
    public void GotoNextPhase()
    {
        int phaseNumber = (int)curPhase;

        if (phaseNumber == 6)
        {
            phaseNumber = 2;
        }
        else
        {
            phaseNumber++;
        }

        curPhase = (CombatPhases)phaseNumber;
    }

    // Checks if the player has won or lost.
    public void CheckWinOrLose()
    {
        
    }

    // Runs though the logic of each phase.
    private void Update()
    {
        int phase = (int)curPhase;

        if (phase == 1)
        {
            foreach (EntitySheet es in entities)
            {
                if (es.tag == "Player")
                {
                    player = es;
                    break;
                }
            }

            if (player == null)
            {
                Debug.LogError("There is no player in the scene add one.");
            }

            // Do other things that are needed for the start of combat.
            GotoNextPhase ();
        }
        else if (phase == 2)
        {
            // Do the things that are needed at the start of the turn.
            foreach (EntitySheet es in entities) 
            {
                foreach (Effect e in es.effectList)
                {
                    e.ExecuteEffectAtStartOfTurn();
                }
            }

            CheckWinOrLose();

            if (isOver == true)
            {
            
            }
            else
            {
                GotoNextPhase();
            }
        }
        else if (phase == 3)
        {
            // Have the attacker pick there action.
        }
        else if (phase == 4)
        {
            // Have the defender pick there action.
        }
        else if (phase == 5)
        {
            // Execute the attacker and defenders moves.

            CheckWinOrLose();

            if (isOver == true)
            {

            }
            else
            {
                GotoNextPhase();
            }
        }
        else if (phase == 6)
        {
            // Do things that are needed at the end of the turn.
            foreach (EntitySheet es in entities) 
            {
                foreach (Effect e in es.effectList)
                {
                    e.ExecuteEffectAtEndOfTurn();
                }
            }

            CheckWinOrLose();

            if (isOver == true)
            {

            }
            else
            {
                GotoNextPhase();
            }
        }
        else if (phase == 7)
        {
            // Do thing that are needed to be done at the end of combate.
        }
        else if (phase == 8)
        {
            // Run logic for the player winning combat.
        }
        else if (phase == 9)
        {
            // Run logic fot the player losing combat.
        }
        else
        {
            Debug.LogError("There is a error in the boundings for the phase [needs to be inbetween 1-9]");
        }
    }
}