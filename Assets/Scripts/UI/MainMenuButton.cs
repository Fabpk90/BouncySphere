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
        SceneManager.LoadScene("Menu");
    }
}
