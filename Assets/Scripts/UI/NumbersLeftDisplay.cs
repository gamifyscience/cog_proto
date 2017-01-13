using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Updates a text label to show how many numbers we've guessed for the current
// bug.
public class NumbersLeftDisplay : MonoBehaviour
{
    private Text m_textLabel;

	private void Awake()
	{
        m_textLabel = GetComponent<Text>();

        if (m_textLabel == null)
        {
            Debug.LogError("Missing Text component!", gameObject);
            enabled = false;
            return;
        }
	}

    private void Start()
    {
        BugGameManager.Instance.OnPhaseChanged += OnPhaseChanged;
    }

    private void OnPhaseChanged(int newPhase)
    {
        if (m_textLabel != null)
        {
            m_textLabel.text = newPhase + "/" + BugGameManager.kNumPhases;
        }
    }
}