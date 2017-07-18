using UnityEngine;
using Assets.Scripts;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public static AsyncOperation levelLoading;

    public static PlayerMovement playerMovement;

    public static void completeLevel(bool IsScoring)
    {
        
        if (IsScoring)
            PlayerData.Scoring(5);

        //resetting the checkpoint index
        PlayerMovement.checkpoint = Vector3.zero;

        //check for best time
        PlayerData.UpdateTimerEndLevel(PlayerMovement.getTimer(), PlayerData.playerData.currentLevel);

        PlayerData.playerData.currentLevel++;

        if (Application.CanStreamedLevelBeLoaded("Level" + PlayerData.playerData.currentLevel))
        {
            if (PlayerData.playerData.currentLevel > PlayerData.playerData.unlockedLevel)
                PlayerData.playerData.unlockedLevel = PlayerData.playerData.currentLevel;

            PlayerData.Save();
            loadLevel(PlayerData.playerData.currentLevel, true);
        }
        else
            loadLevel("FinishGame"); 
    }

    void OnApplicationQuit()
    {
        PlayerData.Save();
    }

    public static void loadLevel(int level, bool loadingScreen)
    {
        PlayerData.playerData.currentLevel = level;

        if (PlayerData.playerData.currentLevel > PlayerData.playerData.unlockedLevel)
            PlayerData.playerData.unlockedLevel = PlayerData.playerData.currentLevel;

        PlayerData.Save();

        if (!loadingScreen)
            SceneManager.LoadScene(level);
        else
            SceneManager.LoadScene("LoadingScene");      
    }

    public static void loadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);    
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            PlayerData.Save();
    }

    public static void SaveAndExit()
    {
        PlayerData.Save();
        Application.Quit();
    }

    public void loadLevel(int level)
    {
        PlayerData.playerData.currentLevel = level;
        SceneManager.LoadScene("LoadingScene");    
    }

    public void Quit()
    {
        PlayerData.Save();
        Application.Quit();
    }

    public void changeSoundLevel(UnityEngine.UI.Slider slider)
    {
        AudioListener.volume = slider.value;
        PlayerData.playerData.soundLevel = slider.value;
    }

    public void erasePlayerData()
    {
        PlayerData.Erase();
    }

    public static void StopTime()
    {
        Time.timeScale = 0;
    }

    public static  void StartTime()
    {
        Time.timeScale = 1.0f;
    }
}