using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = "Level: " + (PlayerData.playerData.currentLevel - 1);
    }
}
