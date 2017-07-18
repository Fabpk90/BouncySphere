using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour {

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    private void clicked()
    {
        GameManager.StartTime();
        PlayerData.Save();
        SceneManager.LoadScene("Menu");
    }
}
