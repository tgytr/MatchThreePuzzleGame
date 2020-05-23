﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class is abstract, use a subclass and re-define the abstract methods
public abstract class LevelGoal : Singleton<LevelGoal>
{
    // the number of stars earned for this level
    public int scoreStars = 0;

    // minimum scores used to earn stars
    public int[] scoreGoals = new int[3] { 1000, 2000, 3000 };

    // number of moves left in this level (replaces GameManager movesLeft)
    public int movesLeft = 30;

    public int timeLeft = 60;

    void Start()
    {
        Init();
    }

    public void Init()
    {

        // reset scoreStars
        scoreStars = 0;

        // doublecheck that scoreGoals are setup in increasing order
        for (int i = 1; i < scoreGoals.Length; i++)
        {
            if (scoreGoals[i] < scoreGoals[i - 1])
            {
                Debug.LogWarning("LEVELGOAL Setup score goals in increasing order!");
            }
        }
    }

    // return number of stars given a score value
    public int UpdateScore(int score)
    {
        for (int i = 0; i < scoreGoals.Length; i++)
        {
            if (score < scoreGoals[i])
            {
                return i;
            }
        }
        return scoreGoals.Length;

    }

    // set scoreStars based on current score
    public void UpdateScoreStars(int score)
    {
        scoreStars = UpdateScore(score);
    }

    // abstract methods to be re-defined in subclass
    public abstract int GetWinner();
    public abstract bool IsGameOver();

}
