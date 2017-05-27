using System;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerData : MonoBehaviour
    {
        public static string playerName = "";

        public static int Score = 0;
        public static int highScore = 0;

        public static int deathCount = 0;

        public static int unlockedLevel = 0;

        public static float soundLevel = 1.0f;
        // Use this for initialization
        void Start()
        {
            //Load();

            //DontDestroyOnLoad(this);

            playerName = PlayerPrefs.GetString("PlayerName");

            Score = PlayerPrefs.GetInt("Score");
            highScore = PlayerPrefs.GetInt("HighScore");

            unlockedLevel = PlayerPrefs.GetInt("Level");

            deathCount = PlayerPrefs.GetInt("DeathCount");

            soundLevel = PlayerPrefs.GetFloat("SoundLevel", -1);

            if (soundLevel == -1)
                soundLevel = 1.0f;

            if (playerName.Length == 0)
                playerName = PlayerNameManager.PlayerName;

            //updates score
            checkScore();  

            //sets the name on the ui
            PlayerNameManager.changeName(playerName);

            //sets the sound volume
            AudioListener.volume = soundLevel;
        }

        public static void Save()
        {
            PlayerPrefs.SetString("PlayerName", playerName);

            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.SetInt("HighScore", highScore);

            PlayerPrefs.SetInt("Level", unlockedLevel);

            PlayerPrefs.SetInt("DeathCount", deathCount);

            PlayerPrefs.SetFloat("SoundLevel", soundLevel);

            PlayerPrefs.Save();
        }

        /*
        public static void Load()
        {
             player = FileManager.Load<PlayerData>("playerData");
        }
        */

        public void Die()
        {
            Score--;
            checkScore();

            deathCount++;
        }

        public static void Scoring()
        {
            Score++;
            checkScore();      
        }

        private static void checkScore()
        {
            if (Score > highScore)
                highScore = Score;

            PlayerScoreManager.checkScore();
        }

        public static void Scoring(int value)
        {
            Score += value;
            checkScore();
        }

        public static void UnScore()
        {
            Score--;
            checkScore();
        }

        public static void UnScore(int value)
        {
            Score -= value;
            checkScore();
        }
    }
}
