﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : Singleton<HomeManager>
{

    public GameObject leaderCharSpace;
    public float timeToMove = 1f;

    public GameObject leaderCharacter;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InitialCharacterMoves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetPlayerLeaderChar()
    {

    }


    void SetPlayerLeaderChar(Image image)
    {
        leaderCharacter.GetComponent<Image>().sprite = image.sprite;

        //if (gameObjectOne.tag == "CoolCloud")
        //{
        //    imageGameObject.GetComponent<Image>().sprite = hammerSprite;
        //}
    }


    IEnumerator InitialCharacterMoves()
    {
        while (true) {
            yield return StartCoroutine(MoveCharDownRoutine(timeToMove));
            yield return StartCoroutine(MoveCharUpRoutine(timeToMove));
        }                                                                     
    }                                                                         

    IEnumerator MoveCharDownRoutine(float timeToMove)
    {
        Vector3 startPosition = leaderCharSpace.transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y - 120);

		float elapsedTimeDown = 0f;

        while (elapsedTimeDown <= 1)
		{
            // track the total running time
            elapsedTimeDown += Time.deltaTime;

            // calculate the Lerp value
            float t = Mathf.Clamp(elapsedTimeDown / timeToMove, 0f, 1f);

            //	case InterpType.SmootherStep:
            t = t * t * t * (t * (t * 6 - 15) + 10);

            // move the game piece
            leaderCharSpace.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }

    IEnumerator MoveCharUpRoutine(float timeToMove)
    {
        Vector3 startPosition = leaderCharSpace.transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + 120);

        float elapsedTimeDown = 0f;

        while (elapsedTimeDown <= 1)
        {
            // track the total running time
            elapsedTimeDown += Time.deltaTime;

            // calculate the Lerp value
            float t = Mathf.Clamp(elapsedTimeDown / timeToMove, 0f, 1f);

            //	case InterpType.SmootherStep:
            t = t * t * t * (t * (t * 6 - 15) + 10);

            // move the game piece
            leaderCharSpace.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }

    public void PlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void ProfileClicked()
    {
        SceneManager.LoadScene("UserProfile");
    }
}
