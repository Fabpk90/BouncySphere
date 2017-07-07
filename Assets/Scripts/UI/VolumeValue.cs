using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class VolumeValue : MonoBehaviour {
	

    void Start()
    {
        GetComponent<Text>().text = "" + Mathf.Floor(PlayerData.playerData.soundLevel * 100);
    }


	public void updateText(Text textToUpdate) {

        textToUpdate.text = "" + Mathf.Floor(PlayerData.playerData.soundLevel * 100);

	}
}
