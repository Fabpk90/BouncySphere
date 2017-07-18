using Assets.Scripts;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestTime : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerDataTime bestTimer = null;

        foreach(PlayerDataTime timer in PlayerData.playerData.listTime)
        {
            if(timer.Level == PlayerData.playerData.currentLevel)
            {
                bestTimer = timer;
            }
        }

        if (bestTimer == null)
            Destroy(gameObject);
        else
            GetComponent<Text>().text = "Best Time\n" + NumberUtility.GetTimerFromSeconds(bestTimer.Seconds);
    }
}
