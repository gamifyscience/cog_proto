using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class msScoreListener : MonoBehaviour
{

    public float currentTime;
    public float grabTime;
    public float score;
    public float newScore;
    public int count = 0;
    public int errorA = 0;
    public int errorB = 0;
    public int errorC = 0;
    public int itemCount = 0;
    public int round = 0;
    public Text scoreText;
    public Text countText;
    public Text errorText;


    // Use this for initialization
    void Start()
    {
        msManager.StartListening("ItemSpawned", ItemSpawned);
        msManager.StartListening("Impulse", Impulse);
        msManager.StartListening("GrabTime", GrabTime);
        msManager.StartListening("UpdateScore", UpdateScore);
        msManager.StartListening("ResetScore", ResetScore);
        msManager.StartListening("NewRound", NewRound);
        msManager.StartListening("aiGrab", aiGrab);
        msManager.StartListening("LevelComplete", LevelComplete);
    }

    void onDisable()
    {
        msManager.StopListening("ItemSpawned", ItemSpawned);
        msManager.StopListening("Impulse", Impulse);
        msManager.StopListening("GrabTime", GrabTime);
        msManager.StopListening("UpdateScore", UpdateScore);
        msManager.StopListening("ResetScore", ResetScore);
        msManager.StopListening("NewRound", NewRound);
        msManager.StopListening("aiGrab", aiGrab);
        msManager.StopListening("LevelComplete", LevelComplete);
    }

    void ItemSpawned()
    {
        currentTime = Time.time;
        itemCount = itemCount + 1;
    }

    void GrabTime()
    {
        grabTime = Time.time;
    }

    void UpdateScore()
    {
        if (count <= 10)
        {
            score = grabTime - currentTime;
            newScore = newScore + score;
            print("time to click: " + score);
            count = count + 1;
            Displayscore();
        }
        else
        {
            msManager.TriggerEvent("PressButtonStop");
            LevelComplete();
            NewRound();
        }
    }

    void ResetScore()
    {
        newScore = 0.0f;
        count = 0;
        errorA = errorA + 1;
        errorB = errorB + 1;
        Displayscore();
    }

    void NewRound()
    {
        newScore = 0.0f;
        count = 0;
        round = round + 1;
        Displayscore();
        print("Round: " + round);
    }


    void aiGrab()
    {
        errorB = errorB + 1;
        print("AIGRAB: " + errorB);
    }

    void Impulse()
    {
        print("Impulse triggered");

    }
    void Displayscore()
    {
        scoreText.text = "SCORE: " + newScore.ToString("F2");
        countText.text = count.ToString();
    }

    void LevelComplete()
    {
        errorText.text = errorA.ToString();
        errorText.text = errorB.ToString();
        errorText.text = errorB.ToString() + ":" + errorA.ToString() + "/" + itemCount.ToString();
        Displayscore();
    }
}
