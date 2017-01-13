using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Performs all the business logic for the AR bug minigame.
public class BugGameManager : MonoBehaviour
{
    // These specify the range of possible random numbers (inclusive).
    private const int kRandomMin = 1;
    private const int kRandomMax = 20;

    private int m_previousNumber;
    private int m_currentNumber;
    private int m_currentPhase = 1;
    private const int kNumPhases = 5;

    public delegate void NumberChangedDelegate(int newNumber);
    public NumberChangedDelegate OnNumberChanged;

    void Start()
	{
        m_previousNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax);

        BugTargeting.Instance.OnTargetingChanged += OnTargetingChanged;
    }

    // Called when the user clicks a higher/lower button.
    public void ProcessUserInput(bool higher)
    {
        // If the user guessed right, advance to the next phase
        if (higher == (m_currentNumber > m_previousNumber))
        {
            ++m_currentPhase;

            if (m_currentPhase > kNumPhases)
            {
                // We've finished all the phases, so erase the bug.
                BugTargeting.Instance.DestroyCurrentTarget();
            }
        }
        // Otherwise, reset to phase 1
        else
        {
            m_currentPhase = 1;
        }

        //
        
        // Get a new number that's different from the previous one.
        m_previousNumber = m_currentNumber;
        m_currentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax, m_previousNumber);
    }

    private void OnTargetingChanged(GameObject oldTarget, GameObject newTarget, BugTargeting.eTargetingState oldState, BugTargeting.eTargetingState newState)
    {
        if (newTarget == null)
        {
            // There's no target focused, so reset to the first phase.
            m_currentPhase = 1;
            return;
        }

        if (oldTarget != newTarget)
        {
            // Get a new number that is different from the previous one
            m_currentNumber = RandomUtils.GetRandom(kRandomMin, kRandomMax, m_previousNumber);

            if (OnNumberChanged != null)
                OnNumberChanged(m_currentNumber);
        }
    }
}