using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public static string PlayerName;

    // Use this for initialization
    void Start()
    {
       //DontDestroyOnLoad(this);
       GetComponent<Text>().text = PlayerName;    
    }

    public static void changeName(string newName)
    {
        PlayerName = newName;
    }
}

