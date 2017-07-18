using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class PlayerNameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       //DontDestroyOnLoad(this);
       GetComponent<Text>().text = PlayerData.playerData.playerName;    
    }

}

