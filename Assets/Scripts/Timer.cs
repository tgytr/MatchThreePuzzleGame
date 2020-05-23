using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Text timeLeftText;
	public Image clockImage;

	int m_maxTime = 60;
	public bool paused = false;

	public int flashTimeLimit = 15;
	public float flashInterval = 15;

	public Color flashColor = Color.red;

	IEnumerator FlashRoutine(Image image, Color targetColor, float interval)
	{
		if (image != null)
		{
			Color originalColor = image.color;
			image.CrossFadeColor(targetColor, interval * 0.3f, true, true);
			yield return new WaitForSeconds(interval * 0.5f);

			image.CrossFadeColor(targetColor, interval * 0.3f, true, true);
			yield return new WaitForSeconds(interval * 0.5f);
		}
	}

	public void initTimer(int maxTime = 60)
	{
		m_maxTime = maxTime;

		if (timeLeftText != null)
		{
			timeLeftText.text = maxTime.ToString();
		}
	}

	public void UpdateTimer(int currentTime)
	{
		if (paused)
		{
			return;
		}

		if (clockImage != null)
		{
			clockImage.fillAmount = (float) currentTime / (float) m_maxTime;

			if (currentTime <= flashTimeLimit)
			{
				StartCoroutine(FlashRoutine(clockImage, flashColor, flashInterval));
			}
		}

		if (timeLeftText != null)
		{
			timeLeftText.text = currentTime.ToString();
		}
	}
}
