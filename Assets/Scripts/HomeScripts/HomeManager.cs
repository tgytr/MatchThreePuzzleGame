using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{

    public GameObject leaderCharSpace;
    public float timeToMove = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitialCharacterMoves());

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetPlayerLeaderChar()
    {

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
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y-120);

		float elapsedTimeDown = 0f;

        while (elapsedTimeDown <= 1)
		{
            // track the total running time
            elapsedTimeDown += Time.deltaTime;
            Debug.Log(elapsedTimeDown);
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

        float elapsedTime = 0f;

        while (elapsedTime <= 1)
        {
            // track the total running time
            elapsedTime += Time.deltaTime;

            // calculate the Lerp value
            float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);

            //	case InterpType.SmootherStep:
            t = t * t * t * (t * (t * 6 - 15) + 10);

            // move the game piece
            leaderCharSpace.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }
}
