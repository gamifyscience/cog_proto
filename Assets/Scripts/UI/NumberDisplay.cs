﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Waits for the current number to change and updates our text label accordingly.
public class NumberDisplay : MonoBehaviour
{
    private Text m_textLabel;

	private void Awake()
	{
        m_textLabel = GetComponent<Text>();

        if (m_textLabel == null)
        {
            Debug.LogError("Missing Text component!", gameObject);
            enabled = false;
        }
	}

    private void Start()
    {
		var bugGameManager = HiLoManager.Instance;

        OnNumberChanged(bugGameManager.CurrentNumber);
        bugGameManager.OnNumberChanged += OnNumberChanged;
    }

    private void OnNumberChanged(int newNumber)
    {
        if (m_textLabel != null)
        {
            m_textLabel.text = newNumber.ToString();
        }
    }
}