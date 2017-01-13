using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Waits for the current number to change and updates our text label accordingly.
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