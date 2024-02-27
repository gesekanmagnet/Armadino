using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static EnumManager.Phase currentPhase;

    [Range(1, 10)]
    public int playOnLevel;

    public List<LevelManager> levelManagers;
    public UIManager uIManager;

    private Dictionary<int, LevelManager> LevelDictionary = new Dictionary<int, LevelManager>();

    public static int attempt;
    public int jump {get; set;}
    public int crouch {get; set;}
    private float time;
    public static int PlayOnLevel {get; set;}

    private void Awake() {
        if(PlayOnLevel == 0) PlayOnLevel = playOnLevel;
        StartGame(PlayOnLevel);
        uIManager.SetCurrentLevel(PlayOnLevel.ToString());
    }

    private void Update() {
        GameSetting(currentPhase);
    }

    public void StartGame(int level)
    {
        PlayOnLevel = level;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        foreach (var item in levelManagers)
        {
            LevelDictionary[item.Level] = item;
        }

        if(LevelDictionary.ContainsKey(level))
        {
            PlayerController.start = LevelDictionary[level].transform;
            PlayerController.finish = LevelDictionary[level].Finish;
        }
        else
        {
            Debug.LogError("Integer is not readable. Only 1-10 are available");
        }

        currentPhase = EnumManager.Phase.START;
    }

    void GameSetting(EnumManager.Phase phase)
    {
        if(phase == EnumManager.Phase.GAMEOVER)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            attempt++;
        }

        if(phase == EnumManager.Phase.PAUSE)
        {
            Time.timeScale = 0;
            uIManager.pausePanel.SetActive(true);
        }

        if(phase == EnumManager.Phase.FINISH)
        {
            uIManager.panel.SetActive(true);
            uIManager.SetLog(attempt.ToString(), jump.ToString(), crouch.ToString(), time);
        }
        
        if(phase == EnumManager.Phase.START)
        {
            time += Time.deltaTime;
            Time.timeScale = 1;
            uIManager.pausePanel.SetActive(false);
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}