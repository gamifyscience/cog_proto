using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The script for the "Higher" and "Lower" buttons. Feeds input into BugGameManager.
public class HigherLowerButton : MonoBehaviour
{
    // Is this the "Higher" button? (If not, it's the "Lower" button)
    public bool m_isHigherButton = false;

    private Button m_button;

	void Awake()
	{
        m_button = GetComponent<Button>();

        if (m_button == null)
        {
            Debug.LogError("Missing Button component!", gameObject);
            enabled = false;
            return;
        }

        m_button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
		HiLoManager.Instance.ProcessPlayerGuess(m_isHigherButton);
    }
}