using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Singleton manager class to keep track of our score
public class ScoreManager : Singleton<ScoreManager>
{
	// our current score
	int m_playerOneScore = 0;
	int m_playerTwoScore = 0;

	public bool isPlayerOne = true;

	// read-only Property to refer to our current score publicly
	public int PlayerScore
	{
		get
		{
			return m_playerOneScore;
		}
	}

	public int OpponentPlayerScore
	{
		get
		{
			return m_playerTwoScore;
		}
	}

	// used to hold a "counter" show the score increment upward to current score
	int m_playerOnecounterValue = 0;

	int m_playerTwocounterValue = 0;

	// amount to increment the counter
	int m_increment = 5;

	// UI.Text that shows the score
	public Text scoreTextPlayerOne;
	public Text scoreTextPlayerTwo;


	public float countTime = 1f;

	// Use this for initialization
	void Start()
	{
		UpdateScoreText(m_playerOneScore);
	}

	// update the UI score Text
	public void UpdateScoreText(int scoreValue)
	{
		if (isPlayerOne == true)
		{
			if (scoreTextPlayerOne != null)
			{
				scoreTextPlayerOne.text = scoreValue.ToString();
			}
		}
		else
		{
			if (scoreTextPlayerTwo != null)
			{
				scoreTextPlayerTwo.text = scoreValue.ToString();
			}
		}
		
	}

	// add a value to the current score
	public void AddScore(int value)
	{

		if (isPlayerOne == true)
		{
			m_playerOneScore += value;
		}
		else
		{
			m_playerTwoScore += value;
		}
		
		StartCoroutine(CountScoreRoutine());
	}

	// coroutine shows the score counting up the currentScore value
	IEnumerator CountScoreRoutine()
	{
		int iterations = 0;

		if (isPlayerOne == true)
		{
			while (m_playerOnecounterValue < m_playerOneScore && iterations < 100000)
			{
				m_playerOnecounterValue += m_increment;
				UpdateScoreText(m_playerOnecounterValue);
				iterations++;
				yield return null;
			}

			//... set the counter equal to the currentScore and update the score Text
			m_playerOnecounterValue = m_playerOneScore;
			UpdateScoreText(m_playerOneScore);
		}
		else
		{
			while (m_playerTwocounterValue < m_playerTwoScore && iterations < 100000)
			{
				m_playerTwocounterValue += m_increment;
				UpdateScoreText(m_playerTwocounterValue);
				iterations++;
				yield return null;
			}

			//... set the counter equal to the currentScore and update the score Text
			m_playerTwocounterValue = m_playerTwoScore;
			UpdateScoreText(m_playerTwoScore);
		}
	}
}
