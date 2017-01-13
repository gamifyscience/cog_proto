using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Performs all the business logic for the AR bug minigame.
public class BugGameManager : MonoBehaviour
{
    public static BugGameManager Instance { get; private set; }
    public IntDelegate OnNumberChanged;
    public IntDelegate OnPhaseChanged;

    public delegate void IntDelegate(int newNumber);

    public int CurrentNumber { get; private set; }
    public const int kNumPhases = 5;

    private int m_previousNumber;

    // These specify the range of possible random numbers (inclusive).
    private const int kRandomMin = 1;
    private const int kRandomMax = 20;

    // Tracks how many numbers we've guessed for the current bug.
    private int m_currentPhase = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate BugGameManager detected. Destroying...");
            Destroy(Instance);
        }

        Instance = this;

        // This value will be moved into m_previousNumber as soon as we look at a bug
        CurrentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax);
    }

    private void Start()
	{
        if (OnNumberChanged != null)
            OnNumberChanged(CurrentNumber);

        BugTargeting.Instance.OnTargetingChanged += OnTargetingChanged;
    }

    // Called when the user clicks a higher/lower button.
    public void ProcessPlayerGuess(bool higher)
    {
        if (!BugTargeting.Instance.HasTarget())
            return;

        // If the user guessed right, advance to the next phase
        if (higher == (CurrentNumber > m_previousNumber))
        {
            ++m_currentPhase;

            if (m_currentPhase > kNumPhases)
            {
                // We've finished all the phases, so erase the bug.
                BugTargeting.Instance.DestroyCurrentTarget();

                m_currentPhase = 1;
            }
        }
        // If the user was wrong, reset to phase 1
        else
        {
            m_currentPhase = 1;
        }

        // Get a new number that's different from the previous one.
        m_previousNumber = CurrentNumber;
        CurrentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax, m_previousNumber);

        if (OnNumberChanged != null)
            OnNumberChanged(CurrentNumber);

        if (OnPhaseChanged != null)
            OnPhaseChanged(m_currentPhase);
    }

    private void OnTargetingChanged(GameObject oldTarget, GameObject newTarget, BugTargeting.eTargetingState oldState, BugTargeting.eTargetingState newState)
    {
        if (newTarget == null)
        {
            // There's no target focused, so reset to the first phase.
            m_currentPhase = 1;

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