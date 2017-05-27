using UnityEngine;
using Assets.Scripts;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public static int currentLevel = 0;
    private static int maxLevel; 
   
    // Use this for initialization
    void Start()
    {
       /* if(gameManager == null)
            gameManager = this;
        else
            Destroy(this);*/

        //gets the number of level
        maxLevel = SceneManager.sceneCountInBuildSettings;

        //gets the currenlevel
        currentLevel = PlayerPrefs.GetInt("Level");
    }

    public static void completeLevel(bool IsScoring)
    {
        //checking if there is more levels
        if (currentLevel + 1 <= maxLevel - 1)
        {          
            if(IsScoring)        
                PlayerData.Scoring(5);

            //resetting the checkpoint index
            PlayerMovement.checkpoint = Vector3.zero;

            PlayerData.unlockedLevel++;
            currentLevel++;

            PlayerData.Save();
            loadLevel(currentLevel, true);
        }
        else
            Application.Quit();

        //System.GC.Collect();
    }

    void OnApplicationQuit()
    {
        PlayerData.Save();
        GC.Collect();
    }

    public static void loadLevel(int level, bool loadingScreen)
    {
        if(!loadingScreen)
            SceneManager.LoadScene(level);
        else
            SceneManager.LoadScene("LoadingScene");
    }

    public void loadLevel(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene("LoadingScene");    
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void changeSoundLevel(UnityEngine.UI.Slider slider)
    {
        AudioListener.volume = slider.value;
        PlayerData.soundLevel = slider.value;
    }

    public void erasePlayerData()
    {
        /*
        PlayerPrefs.SetString("PlayerName", "");

         PlayerPrefs.SetInt("Score", 0);
         PlayerPrefs.SetInt("HighScore", 0);

        PlayerPrefs.SetInt("Level", 0);

        PlayerPrefs.SetInt("DeathCount", 0);     */

        PlayerPrefs.DeleteAll();

        PlayerPrefs.Save();
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