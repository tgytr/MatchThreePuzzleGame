using UnityEngine;
using System.Collections;

public class GameCharacter : MonoBehaviour
{
    public int x;
    public int y;

    public InterpType interpolation = InterpType.SmootherStep;

    public enum InterpType
    {
        Linear,
        EaseOut,
        EaseIn,
        SmoothStep,
        SmootherStep
    };

    public void SetCoord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

	public void Move(int destX, int destY, float timeToMove)
	{
			StartCoroutine(MoveRoutine(new Vector3(destX, destY, 0), timeToMove));
	}


	IEnumerator MoveRoutine(Vector3 destination, float timeToMove)
	{
		Vector3 startPosition = transform.position;

		float elapsedTime = 0f;

		while (true)
		{
			// track the total running time
			elapsedTime += Time.deltaTime;

			// calculate the Lerp value
			float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);

			switch (interpolation)
			{
				case InterpType.Linear:
					break;
				case InterpType.EaseOut:
					t = Mathf.Sin(t * Mathf.PI * 0.5f);
					break;
				case InterpType.EaseIn:
					t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
					break;
				case InterpType.SmoothStep:
					t = t * t * (3 - 2 * t);
					break;
				case InterpType.SmootherStep:
					t = t * t * t * (t * (t * 6 - 15) + 10);
					break;
			}

			// move the game piece
			transform.position = Vector3.Lerp(startPosition, destination, t);

			// wait until next frame
			yield return null;
		}
	}
}
