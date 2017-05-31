using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    public int minChar = 3;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
    }

    public void startGame(Text playerName)
    {
        if(playerName.text != null && playerName.text.Length >= minChar)
        {       
            PlayerNameManager.changeName(playerName.text);

            PlayerPrefs.SetString("PlayerName", playerName.text);

            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("HighScore", 0);

            PlayerPrefs.SetInt("Level", 1);

            //because the first true level is index 1
            PlayerPrefs.SetInt("LevelUnlocked", 1);

            PlayerPrefs.Save();

            GameManager.loadLevel("InstructionsLevel");
        }
          
    }
}
