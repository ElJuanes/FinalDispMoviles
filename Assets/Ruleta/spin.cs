using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spin : MonoBehaviour
{
    public AnimationCurve spinCurve;
    public float minSpins = 3;
    public float maxSpins = 5;
    public float timePerSpin = 1f;
    public float timeRotate;
    public Transform wheel;
    public TextMeshPro resultText;

    private const int NumOptions = 8;
    private const float SectionAngle = 360f / NumOptions;

    private bool isSpinning = false;

    IEnumerator RotateWheel()
    {
        isSpinning = true;

        float totalSpins = Random.Range(minSpins, maxSpins + 1); // Randomize number of spins
        float startAngle = wheel.eulerAngles.z;
        float targetAngle = startAngle + totalSpins * 360f;

        float elapsedTime = 0f;

        while (elapsedTime < totalSpins * timePerSpin)
        {
            float t = elapsedTime / (totalSpins * timePerSpin);
            float curveValue = spinCurve.Evaluate(t);
            float newAngle = Mathf.Lerp(startAngle, targetAngle, curveValue);
            wheel.eulerAngles = new Vector3(0, 0, newAngle);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Determine the number based on the landed angle
        int landedNumber = GetLandedNumber(wheel.eulerAngles.z);

        // Update the UI with the result
        resultText.text = landedNumber.ToString();

        isSpinning = false;
    }

    int GetLandedNumber(float angle)
    {
        angle %= 360f; // Ensure angle is within range [0, 360)

        if (angle >= 0 && angle < 50)
        {
            Debug.Log("Landed on section 1");
            return 1;
        }
        else if (angle >= 50 && angle < 96)
        {
            Debug.Log("Landed on section 2");
            return 2;
        }
        else if (angle >= 96 && angle < 141)
        {
            Debug.Log("Landed on section 3");
            return 3;
        }
        else if (angle >= 141 && angle < 181)
        {
            Debug.Log("Landed on section 4");
            return 4;
        }
        else if (angle >= 181 && angle < 221)
        {
            Debug.Log("Landed on section 5");
            return 5;
        }
        else if (angle >= 221 && angle < 266)
        {
            Debug.Log("Landed on section 6");
            return 6;
        }
        else if (angle >= 266 && angle < 311)
        {
            Debug.Log("Landed on section 7");
            return 7;
        }
        else
        {
            Debug.Log("Landed on section 8");
            return 8;
        }
    }

    [ContextMenu("Rotate")]
    public void RotateNow()
    {
        if (!isSpinning)
            StartCoroutine(RotateWheel());
    }
}

    