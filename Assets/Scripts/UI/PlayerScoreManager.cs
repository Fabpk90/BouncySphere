using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class PlayerScoreManager : MonoBehaviour
{
    private static Text scoreText;

    // Use this for initialization
    void Start()
    {
       // DontDestroyOnLoad(this);
        scoreText = GetComponent<Text>();
        checkScore();
    }

    public static void checkScore()
    {
        if(scoreText != null)
        {
            //makes the score red if it's negative
            if (PlayerData.playerData.Score < 0)
                scoreText.color = new Color(1, 0, 0);
            else if (PlayerData.playerData.Score > 0)
                scoreText.color = new Color(0, 1, 0);
            else
                scoreText.color = new Color(1, 1, 1);

            scoreText.text = "Score: " + PlayerData.playerData.Score;
        }
        
    } 
}
