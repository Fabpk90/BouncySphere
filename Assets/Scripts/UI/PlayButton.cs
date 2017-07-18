using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

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
            PlayerData.playerData = new PlayerDataNormal();

            PlayerData.playerData.playerName = playerName.text;

            PlayerData.playerData.Score = 0;
            PlayerData.playerData.highScore = 0;

            PlayerData.playerData.currentLevel = 1;
            PlayerData.playerData.unlockedLevel = 1;

            PlayerData.Save();

            GameManager.loadLevel("InstructionsLevel");
        }
          
    }
}
