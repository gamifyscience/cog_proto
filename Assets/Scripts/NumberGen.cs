using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberGen : MonoBehaviour
{
    public int outcome;
    public int lastRoot = 10;
    public int round = 1;
    public float hiRange = 20f;
    public int NumPause = 4;
    public Text HiLowText;
    public Text Score;

    private int points = 0;
    public bool isTargetAcquired = false;


    void Start()
    {
        StartCoroutine(GenHiLow());
        UpdateScore(points);
        msManager.StartListening("TargetAcquired", TargetAcquired);
        msManager.StartListening("TargetOff", TargetOff);
    }

    void TargetAcquired()
    {
        if (isTargetAcquired == false)
        {
            isTargetAcquired = true;
            StartCoroutine(GenHiLow());
        }
    }

    void TargetOff()
    {
        isTargetAcquired = false;
    }

    IEnumerator GenHiLow()
    {
        print(round);
        if (round <= 15)
        {
            yield return new WaitForSeconds(NumPause);
            if (isTargetAcquired == false)
            {

                float x = Random.Range(2f, lastRoot) / 2;
                float n = Random.Range(x, hiRange);
                int thisRoot = Mathf.RoundToInt(n);

                outcome = 0;
                if (lastRoot <= thisRoot)
                {
                    outcome = 1;
                    if (lastRoot == thisRoot)
                        thisRoot++;
                }


                lastRoot = Mathf.RoundToInt(n);
                HiLowText.text = lastRoot.ToString();
                round++;
            }
        }
    }

    public void CompareOutcome(int compareBool)
    {
        if (outcome == compareBool)
        {
            points++;
            print("on Target: " + isTargetAcquired);
        }
        print(outcome + ":" + compareBool + ":" + points);
        UpdateScore(points);
    }

    private void UpdateScore(int points)
    {
        Score.text = "SCORE: " + points;
    }
}