using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Utils;

public class LevelSelectorPopulator : MonoBehaviour {

    public GameObject levelSelectorContent;
    public LevelSelectorButton levelButton;

    private void Start()
    {
        for(int i = 0; i < PlayerData.playerData.unlockedLevel; i++)
        {
            LevelSelectorButton button = Instantiate(levelButton) as LevelSelectorButton;

            button.transform.Translate(GetComponent<RectTransform>().rect.width / 2
                , -(GetComponent<RectTransform>().rect.height / 3) * (i + 1), 0);


            if (PlayerData.getTimerBylevel(i+1) != null)
            {
                button.GetComponentInChildren<Text>().text = "Level " + (i) + "\n Best Time \n"+ NumberUtility.GetTimerFromSeconds(PlayerData.getTimerBylevel(i+1).Seconds);
            }
            else
                button.GetComponentInChildren<Text>().text = "Level " + (i);

            button.level = i;

            button.transform.SetParent(levelSelectorContent.transform, false);

        }
    }

}
