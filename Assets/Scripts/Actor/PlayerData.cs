using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerData : MonoBehaviour
    {
        public static PlayerDataNormal playerData;

        // Use this for initialization
        void Awake()
        {
            //Load();

            BinaryFormatter bf = new BinaryFormatter();

            FileStream saveFile = File.Open("Saves/save.dat", FileMode.Open);

            PlayerDataNormal data = (PlayerDataNormal) bf.Deserialize(saveFile);

            //if it's a proper save
            if (data.playerName != null)
            {
                PlayerData.playerData = new PlayerDataNormal();

                PlayerData.playerData = data;

                //sets the sound volume
                AudioListener.volume = PlayerData.playerData.soundLevel;

                
            }
            else
                Debug.Log("qsdqds");

            saveFile.Close();



            //DontDestroyOnLoad(this);
            /* if (PlayerPrefs.HasKey("PlayerName"))
             {
                 playerName = PlayerPrefs.GetString("PlayerName");

                 Score = PlayerPrefs.GetInt("Score");
                 highScore = PlayerPrefs.GetInt("HighScore");

                 unlockedLevel = PlayerPrefs.GetInt("LevelUnlocked");

                 deathCount = PlayerPrefs.GetInt("DeathCount");

                 if (playerName.Length == 0)
                     playerName = PlayerNameManager.PlayerName;

                 //updates score
                 checkScore();

                 //sets the name on the ui
                 PlayerNameManager.changeName(playerName);


             }*/

            //soundLevel = PlayerPrefs.GetFloat("SoundLevel", -1);    



        }

        public static void Save()
        {
            if (!Directory.Exists("Saves"))
                Directory.CreateDirectory("Saves");


            if (playerData == null)
            {
                playerData = new PlayerDataNormal();
                playerData.playerName = null;
            }

            FileStream saveFile = File.Create("Saves/save.dat");

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveFile, playerData);

            saveFile.Close();


            /*PlayerPrefs.SetString("PlayerName", PlayerData.playerData.playerName);

            PlayerPrefs.SetInt("Score", PlayerData.playerData.Score);
            PlayerPrefs.SetInt("HighScore", PlayerData.playerData.highScore);

            PlayerPrefs.SetInt("LevelUnlocked", PlayerData.playerData.unlockedLevel);
            PlayerPrefs.SetInt("Level", GameManager.currentLevel);

            PlayerPrefs.SetInt("DeathCount", PlayerData.playerData.deathCount);

            PlayerPrefs.SetFloat("SoundLevel", PlayerData.playerData.soundLevel);

            PlayerPrefs.Save();*/
        }

        /*
        public static void Load()
        {
             player = FileManager.Load<PlayerData>("playerData");
        }
        */

        public void Die()
        {
            playerData.Score--;
            checkScore();

            playerData.deathCount++;
        }

        public static void Erase()
        {
            File.Delete("Saves/save.dat");
            playerData = null;
        }

        public static void Scoring()
        {
            PlayerData.playerData.Score++;
            checkScore();      
        }

        private static void checkScore()
        {
            if (PlayerData.playerData.Score > PlayerData.playerData.highScore)
                PlayerData.playerData.highScore = PlayerData.playerData.Score;

            PlayerScoreManager.checkScore();
        }

        public static void Scoring(int value)
        {
            PlayerData.playerData.Score += value;
            checkScore();
        }

        public static void UnScore()
        {
            PlayerData.playerData.Score--;
            checkScore();
        }

        public static void UnScore(int value)
        {
            PlayerData.playerData.Score -= value;
            checkScore();
        }
    }

    [System.Serializable]
    class PlayerDataNormal
    {
        public string playerName = "";

        public int Score = 0;
        public int highScore = 0;

        public int deathCount = 0;

        public int unlockedLevel = 0;
        public int currentLevel = 0;

        public float soundLevel = 1.0f;
    }
}
