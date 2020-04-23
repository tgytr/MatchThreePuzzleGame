using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int x;
    public int y;

    bool isMoving = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move((int)transform.position.x + 1, (int) transform.position.y, 0.5f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move((int)transform.position.x - 1, (int) transform.position.y, 0.5f);
        }
    }




    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Move(int destX, int destY, float timeToMove)
    {
        if (!isMoving)
        {
            StartCoroutine(MoveRoutine(new Vector3(destX, destY, 0), timeToMove));

        }
    }

    IEnumerator MoveRoutine(Vector3 destination, float timeToMove)
    {
        Vector3 startPosition = transform.position;
        bool reachDestination = false;
        float elapsedTime = 0f;
        isMoving = true;

        while (!reachDestination)
        {
            //do something usefulll
            //....
            if (Vector3.Distance(transform.position, destination) < 0.01f)
            {
                reachDestination = true;
                transform.position = destination;
                SetCoordinates((int)destination.x, (int)destination.y);
                break;
            }

            elapsedTime += Time.deltaTime;
            float t = elapsedTime / timeToMove;

            transform.position = Vector3.Lerp(startPosition, destination, t);

            //wait until next frame
            yield return null;
        }
        isMoving = false;
    }
}
