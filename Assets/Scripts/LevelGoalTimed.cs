using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoalTimed : LevelGoal
{

    public Timer timer;
    private void Start()
    {
        if (timer != null)
        {
            timer.initTimer(timeLeft);
        }
    }

    // start the countdown timer
    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    // decrement timeLeft each second
    IEnumerator CountdownRoutine()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;

            if (timer != null)
            {
                timer.UpdateTimer(timeLeft);
            }
        }
    }

    // did we win?
    public override int GetWinner()
    {

        // we scored higher than the lowest score goal, we win
        if (ScoreManager.Instance != null)
        {
            if(ScoreManager.Instance.PlayerScore > ScoreManager.Instance.OpponentPlayerScore)
            {
                //should return player later
                return 1;
            }else if (ScoreManager.Instance.PlayerScore < ScoreManager.Instance.OpponentPlayerScore)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }

    // is the game over?
    public override bool IsGameOver()
    {
        int maxScore = scoreGoals[scoreGoals.Length - 1];

        // if we score higher than the last score goal, end the game
        if (ScoreManager.Instance.PlayerScore >= maxScore)
        {
            return true;
        }

        // end the game if we have no more time
        return (timeLeft <= 0);
    }
}
