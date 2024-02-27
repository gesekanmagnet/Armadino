using System;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameManager gameManager;

    public GameObject panel;
    public GameObject pausePanel;
    
    public Text currentLevel;
    public Text Attempt, Jump, Crouch, Time;
    public Text logError;

    public void SetLog(string attempt, string jump, string crouch, float time)
    {
        Attempt.text = attempt;
        Jump.text = jump;
        Crouch.text = crouch;
        
        var ts = TimeSpan.FromSeconds(time);
        Time.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }

    public void SetLevel(InputField input)
    {
        if(int.TryParse(input.text, out int x))
        {
            Debug.Log(x);
            if(x < 1 || x > 10)
            {
                logError.gameObject.SetActive(true);
                logError.text = "There's no level" + input.text;
            }
            else
            {
                gameManager.StartGame(x);
            }

        }
        else
        {
            Debug.LogError("InputField NullReference");
        }
    }

    public void SetCurrentLevel(string x)
    {
        currentLevel.text = "Level " + x;
    }
}