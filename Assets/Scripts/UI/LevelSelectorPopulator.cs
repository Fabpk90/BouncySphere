using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class LevelSelectorPopulator : MonoBehaviour {

    public GameObject levelSelectorContent;
    public LevelSelectorButton levelButton;

    private void Start()
    {

        for(int i = 0; i < PlayerData.playerData.unlockedLevel; i++)
        {
            LevelSelectorButton button = Instantiate(levelButton) as LevelSelectorButton;

            button.transform.Translate(GetComponent<RectTransform>().rect.width / 2
                , -GetComponent<RectTransform>().rect.height * (i + 1), 0);

            button.GetComponentInChildren<Text>().text = "Level " + (i);

            //+1 because level 0 is the menu
            button.level = i+1;

            button.transform.SetParent(levelSelectorContent.transform);

        }
    }

}
