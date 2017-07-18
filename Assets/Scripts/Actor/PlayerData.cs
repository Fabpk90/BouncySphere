
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerData : MonoBehaviour
    {
        public static PlayerDataNormal playerData;

        // Use this for initialization
        void OnEnable()
        {

            if (Directory.Exists(Application.persistentDataPath + "/save"))
            {
                BinaryFormatter bf = new BinaryFormatter();

                FileStream saveFile = File.Open(Application.persistentDataPath + "/save/save.dat", FileMode.Open);

                PlayerDataNormal data = (PlayerDataNormal)bf.Deserialize(saveFile);

                //if it's a proper save
                if (data.playerName != null)
                {
                    

                    PlayerData.playerData = data;

                    //sets the sound volume
                    AudioListener.volume = PlayerData.playerData.soundLevel;


                }
                else
                    print("load error");

                saveFile.Close();
            }

              

            //soundLevel = PlayerPrefs.GetFloat("SoundLevel", -1);    



        }

        public static void Save()
        {
            if (!Directory.Exists(Application.persistentDataPath+"/save"))
                Directory.CreateDirectory(Application.persistentDataPath+"/save");


            if (PlayerData.playerData == null)
            {
                print("playerdata null");
                playerData = new PlayerDataNormal();
                playerData.playerName = null;
            }

            FileStream saveFile = File.Create(Application.persistentDataPath+"/save/save.dat");

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(saveFile, playerData);

            saveFile.Close();


        }

        public void Die()
        {
            playerData.Score--;
            checkScore();

            playerData.deathCount++;
        }

        public static void Erase()
        {
            File.Delete(Application.persistentDataPath+"/save/save.dat");
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

        public static bool UpdateTimerEndLevel(float seconds, int level)
        {
            bool updated = false;
            bool found = false;

            foreach(PlayerDataTime timer in playerData.listTime)
            {
                if (timer.Level == level)
                {
                    found = true;
                    if (timer.Seconds > seconds)
                    {
                        timer.Seconds = seconds;
                        updated = true;
                    }
                }         
            }

            if(!found)
            {
                playerData.listTime.Add(new PlayerDataTime(seconds, playerData.currentLevel));
                updated = true;
            }

            return updated;
        }

        public static bool UpdateTimerEndLevel(PlayerDataTime timer)
        {
          return UpdateTimerEndLevel(timer.Seconds, timer.Level);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns>return the index in the list, -1 if not found</returns>
        public static int getTimerIndexByLevel(int level)
        {
            for(int i = 0; i < playerData.listTime.Count; ++i)
            {
                if (playerData.listTime[i].Level == level)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns>timer or null</returns>
        public static PlayerDataTime getTimerBylevel(int level)
        {
            foreach(PlayerDataTime timer in playerData.listTime)
            {
                if (timer.Level == level)
                    return timer;
            }

            return null;
        }
    }

    [System.Serializable]
    class PlayerDataNormal
    {
        public string playerName;

        public int Score = 0;
        public int highScore = 0;

        public int deathCount = 0;

        public int unlockedLevel = 0;
        public int currentLevel = 0;

        public float soundLevel = 1.0f;

        public List<PlayerDataTime> listTime = new List<PlayerDataTime>();
    }

    [System.Serializable]
   public class PlayerDataTime
    {
        public float Seconds = -1.0f;
        public int Level = -1;

        public PlayerDataTime(float seconds, int level)
        {
            this.Seconds = seconds;
            this.Level = level;
        }
    }
}
