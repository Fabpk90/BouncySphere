using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Utils;

public class Timer : MonoBehaviour {
	// Update is called once per frame
	void Update () {

        if(PlayerMovement.getTimer() >= 60.0f)
        {
            int minutes = NumberUtility.getMinutes(PlayerMovement.getTimer());
            GetComponent<Text>().text = "Timer: " +minutes+":"+ (PlayerMovement.getTimer() - 60 * minutes ).ToString("0.00");
        }
        else
            GetComponent<Text>().text = "Timer: " + PlayerMovement.getTimer().ToString("0.00");

    }
}
