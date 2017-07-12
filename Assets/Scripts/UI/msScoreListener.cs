using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class msScoreListener : MonoBehaviour
{
    // Timestamp when the most recent box was spawned.
	public float spawnTime = 0.0f;	//time item available
    public float grabTime;	//time item pickedup
	public float score = 0.0f;		//interval score
    public float newScore = 0.0f; //cumalitive score/time
	private bool isBoxOpen = false;
    public Text scoreText;
    public Text countText;
	public Text errorText;
    public Text roundText;
    public int kBoxesPerRound = 6;
	public static int round = 1;
    
	private int boxCount = 1;
    private int itemCount = 0;
    private int errorA = 0; //max 4 errors
    private int errorB = 0;
	public int kMaxErrors = 4;
	private float BestScore = 3;

	//plugin for UI
	public EnergyBar CountBar;
	public EnergyBar RoundBar;
	public EnergyBar ScoreMeter;

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
		isBoxOpen = true;
        spawnTime = Time.time;
        itemCount = itemCount + 1;
    }

    void GrabTime()
    {
        grabTime = Time.time;
    }


	void Update(){

		var meterValue = Mathf.Clamp01 ((Time.time - spawnTime) / boxCount);
		if (isBoxOpen)
			ScoreMeter.ValueF = meterValue;
	}

    void UpdateScore()
	{
		isBoxOpen = false;
	
        if (boxCount < kBoxesPerRound)
        {
            score = grabTime > 0 ? grabTime - spawnTime : 0;
			newScore = newScore + score;
			AnswerCustom.LogDroneJamInterval ("EspiangeRound", "Interval_Score", score);
        }
        else
        {
            NewRound();
        }

		var maxErrors = errorA + errorB;
		if (maxErrors >= kMaxErrors)
		{
			msManager.TriggerEvent ("LevelComplete");
			return;
		}
		DisplayScore();
    }

    void ResetScore()
    {
        newScore = 0.0f;
		grabTime = 0;
        boxCount = 0;
        errorA = errorA + 1;
    }

    void NewRound()
    {
		AnswerCustom.LogDroneJamError ("EspiangeErrors", "Error_Miss", errorB, "Error_Wrong", errorA);
		AnswerCustom.LogDroneJamInterval ("EspiangeRound_w" + kBoxesPerRound.ToString(), "Time", newScore);
		if (newScore < BestScore)
			BestScore = newScore;

        newScore = 0.0f;
        boxCount = 0;
        ++round;
        print("Round: " + round);


    }

    void aiGrab() //player missed item - ai grabbed it
    {
        errorB = errorB + 1;
		boxCount = boxCount - 1;
		itemCount = itemCount -1;
    }

	void aiPass () //plyer correctly let item pass
	{
		grabTime = 0;
		//boxCount = boxCount - 1; //set this value if the narrative is to collect x per round
		itemCount = itemCount -1;
	}

    void Impulse()
    {
        print("Impulse triggered");

    }
    void DisplayScore()
    {
		CountBar.valueCurrent = boxCount;
		RoundBar.valueCurrent = round;

		roundText.text = "ROUNDS: " + round;
		scoreText.text = "SCORE: " + (100*BestScore).ToString("F1");
		errorText.text = "BROKEN: " + errorA.ToString(); //display impulse errors;
		countText.text = "COLLECTED: " + itemCount;
    }

    void LevelComplete()
    {
        DisplayScore();
    }

}
