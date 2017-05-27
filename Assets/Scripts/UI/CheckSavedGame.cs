using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSavedGame : MonoBehaviour {
    public bool callCheck;
    public bool callCheckAndLoad;

    public List<UnityEngine.Object> obj;

    void Start()
    {
        if (callCheck)
            check(obj);
    }

    /// <summary>
    /// Checks if there is a savedgame, if yes delete the param obj and load the first level
    /// </summary>
    /// <param name="objs"></param>
    public void checkAndLoadLevel(UnityEngine.Object objs)
    {
        //the player has a saved game
        /* if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
         {
             Destroy(objs);
             GameManager.completeLevel(false);
         }
        */

        if(PlayerPrefs.HasKey("PlayerName"))
        {
            if(PlayerPrefs.GetInt("Level") == SceneManager.sceneCountInBuildSettings - 1)
            {
                PlayerPrefs.SetInt("Level", 1);
            }

            Destroy(objs);

            GameManager.loadLevel(PlayerPrefs.GetInt("Level"), true);

            Debug.Log("qds");
        }
    }
    /// <summary>
    /// Checks if there is a savedgame, if no delete the param obj
    /// </summary>
    /// <param name="objs"></param>
    public void check(UnityEngine.Object objs)
    {
        
        if (!PlayerPrefs.HasKey("PlayerName"))
        {         
            Destroy(objs);
        }
    }

    private void check(List<UnityEngine.Object> objs)
    {
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            foreach(UnityEngine.Object obj in objs)
                Destroy(obj);
        }
    }
}
