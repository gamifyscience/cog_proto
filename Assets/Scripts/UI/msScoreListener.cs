using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class msScoreListener : MonoBehaviour
{
    // Timestamp when the most recent box was spawned.
    public float spawnTime;
    public float grabTime;
    public float score;
    public float newScore;
    public Text scoreText;
    public Text countText;
    public Text roundText;
    public int kBoxesPerRound = 10;

    private int round = 1;
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
            print("time to click: " + score);
            
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
        boxCount = 0;
        errorA = errorA + 1;
        errorB = errorB + 1;
        DisplayScore();
    }

    void NewRound()
    {
        newScore = 0.0f;
        boxCount = 0;
        ++round;
        DisplayScore();
        print("Round: " + round);
    }


    void aiGrab()
    {
        grabTime = 0f;

        errorB = errorB + 1;
        print("AIGRAB: " + errorB);
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
