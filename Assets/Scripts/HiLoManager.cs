using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Performs all the business logic for the AR bug minigame.
public class HiLoManager : MonoBehaviour
{

	//public string SceneName;
	public static HiLoManager Instance { get; private set; }
    public IntDelegate OnNumberChanged;
    public IntDelegate OnPhaseChanged;
	public IntDelegate OnListChanged;

	public delegate void IntDelegate(int newNumber);

    public int CurrentNumber { get; private set; }
    public const int kNumPhases = 7;

    private int m_previousNumber;

    // HILOGAME These specify the range of possible random numbers (inclusive).
    private const int kRandomMin = 1;
    private const int kRandomMax = 20;

    // Tracks how many numbers we've guessed for the current drone.
    private int m_currentPhase = 0;

	// COUNTSORTGAME These are the ordered lists for the coundown array 
	private static List<int> firstset = new List<int>() {25,24,23,22,21,20,19,18,17,16,15,14};
	private static List<int> orderset = new List<int>() {25,24,23,22,21,20,19,18,17,16,15,14};
	private static List<int> nextset  = new List<int>() {13,12,11,10, 9, 8, 7, 6, 5, 4, 3, 2};
	public static int CountOrder;

    private void Awake()
    {
		//SceneName = "DecoderHiLo";
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate DroneGameManager detected. Destroying...");
            Destroy(Instance);
        }

        Instance = this;

        // This value will be moved into m_previousNumber as soon as we look at a drone
        CurrentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax);
    }

    private void Start()
	{
        if (OnNumberChanged != null)
            OnNumberChanged(CurrentNumber);
		CountOrder = 1;
		//OnListChanged(CountOrder);
        DroneTargeting.Instance.OnTargetingChanged += OnTargetingChanged;

		//count sort random array
		for (int i = 0; i < firstset.Count; i++) {
			int mixedset = firstset[i];
			int randomIndex = Random.Range(i, firstset.Count);
			firstset[i] = firstset[randomIndex];
			firstset[randomIndex] = mixedset;
		}

    }

	//DecoderCountSort grid setup
	public static int OnSetValue ( int indexValue )
	{
		return firstset [indexValue];
	}

	public static int OnGetValue (int testValue, int testPosition)
	{
		//test values and swap with new number if pass
		print(orderset [testPosition]+" @" + testPosition + " was compared to " + testValue + " -from CountOrder  " + CountOrder);
		if (testValue == orderset [testPosition]) {
			int i = nextset [testPosition];
			return i;
		} else {
			return testValue;
		}

	}

    // Called when the user clicks a higher/lower button.
    public void ProcessPlayerGuess(bool higher)
    {
        if (!DroneTargeting.Instance.HasTarget())
            return;
		print("checking high" + higher+ " compared to" + (CurrentNumber > m_previousNumber));
        // If the user guessed right, advance to the next phase
        if (higher == (CurrentNumber > m_previousNumber))
        {
            ++m_currentPhase;

            if (m_currentPhase > kNumPhases)
            {
                // We've finished all the phases, so erase the bug.
                DroneTargeting.Instance.DestroyCurrentTarget();

                m_currentPhase = 0;
            }
        }
        // If the user was wrong, reset to phase 1
        else
        {
            m_currentPhase = 0;
        }

        // Get a new number that's different from the previous one.
        m_previousNumber = CurrentNumber;
        CurrentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax, m_previousNumber);

        if (OnNumberChanged != null)
            OnNumberChanged(CurrentNumber);

        if (OnPhaseChanged != null)
            OnPhaseChanged(m_currentPhase);
    }

	// Called when the user clicks a countsort buttons.
	public void ProcessPlayerSelect(bool higher)
	{
		if (!DroneTargeting.Instance.HasTarget())
			return;

		// If the user guessed right, advance to the next phase
		if (higher)
		{
			++m_currentPhase;

			if (m_currentPhase > kNumPhases)
			{
				// We've finished all the phases, so erase the bug.
				DroneTargeting.Instance.DestroyCurrentTarget();

				m_currentPhase = 0;
			}
		}
		// If the user was wrong, reset to phase 1
		else
		{
			m_currentPhase = 0;
		}

		if (OnPhaseChanged != null)
			OnPhaseChanged(m_currentPhase);
	}

    private void OnTargetingChanged(GameObject oldTarget, GameObject newTarget, DroneTargeting.eTargetingState oldState, DroneTargeting.eTargetingState newState)
    {
        if (newTarget == null)
        {
            // There's no target focused, so reset to the first phase.
            m_currentPhase = 0;

            if (OnPhaseChanged != null)
                OnPhaseChanged(m_currentPhase);

            return;
        }

        if (oldTarget != newTarget)
        {
            // Get a new number that is different from the previous one
            m_previousNumber = CurrentNumber;
            CurrentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax, m_previousNumber);

            if (OnNumberChanged != null)
                OnNumberChanged(CurrentNumber);
        }
    }
}