using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSavedGame : MonoBehaviour {
    public bool callCheck;

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
        if(PlayerData.playerData != null)
        {         
            Destroy(objs);

            GameManager.loadLevel(PlayerData.playerData.currentLevel, true);
        }
    }
    /// <summary>
    /// Checks if there is a savedgame, if no delete the param obj
    /// </summary>
    /// <param name="objs"></param>
    public void check(UnityEngine.Object objs)
    {
        
        if (PlayerData.playerData == null)
        {         
            Destroy(objs);
        }
    }

    private void check(List<UnityEngine.Object> objs)
    {
        if (PlayerData.playerData == null)
        {
            foreach(UnityEngine.Object obj in objs)
                Destroy(obj);
        }
    }
}
