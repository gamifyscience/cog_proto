using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class msScoreListener : MonoBehaviour
{
    // Timestamp when the most recent box was spawned.
    public float spawnTime;	//time item available
    public float grabTime;	//time item pickedup
    public float score;		//interval score
    public float newScore; //cumalitive score/time

    public Text scoreText;
    public Text countText;
    public Text roundText;
    public int kBoxesPerRound = 6;
	public static int round = 1;
    
	private int boxCount = 0;
    private int itemCount = 0;
    private int errorA = 0;
    private int errorB = 0;

    void Start()
    {
        msManager.StartListening("SpawnBox", SpawnBox);
        msManager.StartListening("ItemSpawned", ItemSpawned);
        msManager.StartListening("Impulse", Impulse);
        msManager.StartListening("GrabTime", GrabTime);
        msManager.StartListening("UpdateScore", UpdateScore);
        msManager.StartListening("ResetScore", ResetScore);
        msManager.StartListening("aiGrab", aiGrab);
		msManager.StartListening("aiPass", aiPass);
        msManager.StartListening("LevelComplete", LevelComplete);

        DisplayScore();
    }

    void onDisable()
    {
        msManager.StopListening("SpawnBox", SpawnBox);
        msManager.StopListening("ItemSpawned", ItemSpawned);
        msManager.StopListening("Impulse", Impulse);
        msManager.StopListening("GrabTime", GrabTime);
        msManager.StopListening("UpdateScore", UpdateScore);
        msManager.StopListening("ResetScore", ResetScore);
        msManager.StopListening("aiGrab", aiGrab);
		msManager.StopListening("aiPass", aiPass);
        msManager.StopListening("LevelComplete", LevelComplete);
    }

    private void SpawnBox()
    {
        ++boxCount;
    }

    void ItemSpawned()
    {
        spawnTime = Time.time;
        itemCount = itemCount + 1;
    }

    void GrabTime()
    {
        grabTime = Time.time;
    }

    void UpdateScore()
    {
        if (boxCount < kBoxesPerRound)
        {
            score = grabTime > 0 ? grabTime - spawnTime : 0;
			newScore = newScore + score;
			AnswerCustom.LogDroneJamInterval ("EspiangeRound", "Interval_Score", score);
            DisplayScore();
        }
        else
        {
            msManager.TriggerEvent("LevelComplete");
            NewRound();
        }
    }

    void ResetScore()
    {
        newScore = 0.0f;
		grabTime = 0;
        boxCount = 0;
        errorA = errorA + 1;
        DisplayScore();
    }

    void NewRound()
    {
		//LogDroneJamError (string JamError, string Attribute1, object Detail1, string Attribute2, object Detail2)
		AnswerCustom.LogDroneJamError ("EspiangeErrors", "Error_Miss", errorB, "Error_Wrong", errorA);
		AnswerCustom.LogDroneJamInterval ("EspiangeRound_w" + kBoxesPerRound.ToString(), "Time", newScore);
        newScore = 0.0f;
        boxCount = 0;
        ++round;
        DisplayScore();
        print("Round: " + round);

    }


    void aiGrab()
    {
        errorB = errorB + 1;
    }

	void aiPass ()
	{
		grabTime = 0;
		//boxCount = boxCount - 1; //set this value if the narrative is to collect x per round
	}

    void Impulse()
    {
        print("Impulse triggered");

    }
    void DisplayScore()
    {
        scoreText.text = "SCORE: " + newScore.ToString("F2");
        countText.text = boxCount.ToString();
        roundText.text = "ROUND " + round;
    }

    void LevelComplete()
    {
        //errorText.text = errorB.ToString() + ":" + errorA.ToString() + "/" + itemCount.ToString();

        DisplayScore();
    }
}
