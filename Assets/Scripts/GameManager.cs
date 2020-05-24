using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(LevelGoal))]
public class GameManager : Singleton<GameManager>
{
    // reference to graphic that fades in and out
    public ScreenFader screenFader;

    // UI.Text that stores the level name
    public Text gameStatusText;

    // UI.Text that shows how many moves are left
    public Text movesLeftText;

    // reference to the Board
    Board m_board;

    // is the player read to play?
    bool m_isReadyToBegin = false;

    // is the game over?
    bool m_isGameOver = false;

    public bool IsGameOver
    {
        get
        {
            return m_isGameOver;
        }
        set
        {
            m_isGameOver = value;
        }
    }

    // do we have a winner?
    int m_Winner;


    //These are extra from lesson
    // are we ready to load/reload a new level?
    bool m_isReadyToReload = false;

    // reference to the custom UI window
/*    public MessageWindow messageWindow;

    // sprite for losers
    public Sprite loseIcon;

    // sprite for winners
    public Sprite winIcon;

    // sprite for the level goal
    public Sprite goalIcon;

    public ScoreMeter scoreMeter;*/

    // reference to LevelGoal component
    LevelGoal m_levelGoal;

    // reference to LevelGoalTimed component (null if level is not timed)
    LevelGoalTimed m_levelGoalTimed;


    public override void Awake()
    {
        base.Awake();

        // fill in LevelGoal and LevelGoalTimed components
        m_levelGoal = GetComponent<LevelGoal>();
        m_levelGoalTimed = GetComponent<LevelGoalTimed>();

        // cache a reference to the Board
        m_board = GameObject.FindObjectOfType<Board>().GetComponent<Board>();

    }

    // Use this for initialization
    void Start()
    {

        Scene scene = SceneManager.GetActiveScene();

        

        // update the moves left UI
        //m_levelGoal.movesLeft++;
        //UpdateMoves();

        StartCoroutine("ExecuteGameLoop");
    }


    public void UpdateMoves()
    {
        //this is not needed for first functionality
        // if the LevelGoal is not timed (e.g. LevelGoalScored)...
        if (m_levelGoalTimed == null)
        {

            m_levelGoal.movesLeft--;

            if (movesLeftText != null)
            {
                movesLeftText.text = m_levelGoal.movesLeft.ToString();
            }
        }
        // if the LevelGoal IS timed...
        else
        {
            // change the text to read Infinity symbol
            if (movesLeftText != null)
            {
                movesLeftText.text = "\u221E";
                movesLeftText.fontSize = 70;
            }

        }
    }

    IEnumerator ExecuteGameLoop()
    {

        yield return StartCoroutine("StartGameRoutine");
        yield return StartCoroutine("PlayGameRoutine");

        // wait for board to refill
        //yield return StartCoroutine("WaitForBoardRoutine", 0.5f);

        yield return StartCoroutine("EndGameRoutine");

    }

    // switches ready to begin status to true
    public void BeginGame()
    {
        m_isReadyToReload = true;
        m_isReadyToBegin = true;

    }

    IEnumerator StartGameRoutine()
    {
        while (!m_isReadyToBegin)
        {
            yield return null;
            yield return new WaitForSeconds(2f);
            m_isReadyToBegin = true;
        }

        if (screenFader != null)
        {
            screenFader.FadeOff();
        }

        yield return new WaitForSeconds(0.5f);

        if (m_board != null)
        {
            m_board.SetupBoard();
        }
    }

    IEnumerator PlayGameRoutine()
    {
        // if level is timed, start the timer
        if (m_levelGoalTimed != null)
        {
            m_levelGoalTimed.StartCountdown();
        }
        // while the end game condition is not true, we keep playing
        // just keep waiting one frame and checking for game conditions
        while (!m_isGameOver)
        {

            m_isGameOver = m_levelGoal.IsGameOver();

            m_Winner = m_levelGoal.GetWinner();

            // wait one frame
            yield return null;
        }
    }

    IEnumerator EndGameRoutine()
    {
        // set ready to reload to false to give the player time to read the screen
        m_isReadyToReload = false;

        if (m_Winner.Equals(1))
        {
            Debug.Log("PLAYER 1 WIN!");
            if (gameStatusText != null)
            {
                gameStatusText.text = "PLAYER 1 WIN!";
            }
        }
        else if(m_Winner.Equals(0))
        {
            Debug.Log("DRAW");
            if (gameStatusText != null)
            {
                gameStatusText.text = "DRAW";
            }
        }
        else
        {
            Debug.Log("PLAYER 2 WIN!");
            if (gameStatusText != null)
            {
                gameStatusText.text = "PLAYER 2 WIN!";
            }
        }

        // wait one second
        yield return new WaitForSeconds(1f);

        // fade the screen 
        if (screenFader != null)
        {
            screenFader.FadeOn();
        }

        // wait until read to reload
        while (!m_isReadyToReload)
        {
            yield return null;
        }


        // reload the scene (you would customize this to go back to the menu or go to the next level
        // but we just reload the same scene in this demo
        SceneManager.LoadScene("Main");
    }


    // use this to acknowledge that the player is ready to reload
    public void ReloadScene()
    {
        m_isReadyToReload = true;
    }
}
