using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectorPopulator : MonoBehaviour {

    public GameObject levelSelectorContent;
    public LevelSelectorButton levelButton;

    private void Start()
    {
        for(int i = 0; i < GameManager.currentLevel; i++)
        {
            LevelSelectorButton button = Instantiate(levelButton) as LevelSelectorButton;

            button.transform.Translate(GetComponent<RectTransform>().rect.width / 2
                , -GetComponent<RectTransform>().rect.height * (i + 1), 0);

            button.GetComponentInChildren<Text>().text = "Level " + (i + 1);

            button.level = i;

            button.transform.SetParent(levelSelectorContent.transform);

        }
    }

}
