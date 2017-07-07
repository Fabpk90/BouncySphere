using UnityEngine;
using Assets.Scripts;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    private static int maxLevel;

    public static AsyncOperation levelLoading;
   
    // Use this for initialization
    void Start()
    {
       /* if(gameManager == null)
            gameManager = this;
        else
            Destroy(this);*/

        //gets the number of level
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;

        /*
        if(PlayerPrefs.HasKey("Level"))
            currentLevel = PlayerPrefs.GetInt("Level");*/
    }

    public static void completeLevel(bool IsScoring)
    {
        //checking if there is more levels
        if (PlayerData.playerData.currentLevel + 1 <= maxLevel)
        {
            if (IsScoring)
                PlayerData.Scoring(5);

            //resetting the checkpoint index
            PlayerMovement.checkpoint = Vector3.zero;

            PlayerData.playerData.currentLevel++;

            if (PlayerData.playerData.currentLevel > PlayerData.playerData.unlockedLevel)
                PlayerData.playerData.unlockedLevel = PlayerData.playerData.currentLevel;

            PlayerData.Save();
            loadLevel(PlayerData.playerData.currentLevel, true);
        }
        else
            GameManager.loadLevel(maxLevel, false);
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
        // FileManager.Save(PlayerData.player, typeof(PlayerData), "playerData");
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
        /*
        PlayerPrefs.SetString("PlayerName", "");

         PlayerPrefs.SetInt("Score", 0);
         PlayerPrefs.SetInt("HighScore", 0);

        PlayerPrefs.SetInt("Level", 0);

        PlayerPrefs.SetInt("DeathCount", 0);     */

        PlayerData.Erase();


        /*PlayerPrefs.DeleteKey("PlayerName");

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        GameManager.currentLevel = 0;
        PlayerData.unlockedLevel = 0;*/
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