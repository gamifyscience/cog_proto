using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOnClick : MonoBehaviour
{
    private bool m_isPaused = false;

    void Start()
    {
        var button = GetComponent<Button>();
        if (!button)
        {
            Debug.LogError("Missing button component", gameObject);
            enabled = false;
            return;
        }

        button.onClick.AddListener(OnClick);
    }

    void OnDestroy()
    {
        var button = GetComponent<Button>();
        if (button)
            button.onClick.RemoveListener(OnClick);
    }

    void OnClick()
    {
        m_isPaused = !m_isPaused;

        Time.timeScale = m_isPaused ? 0f : 1f;
        GetComponent<Image>().color = m_isPaused ? Color.red : Color.white;
    }
}
