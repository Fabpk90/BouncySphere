using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectorButton : MonoBehaviour {

    public int level;

    public LevelSelectorButton(int level)
    {
        this.level = level;
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener( () => ButtonPushed());
    }

    void ButtonPushed()
    {
        GameManager.loadLevel(level + 1, true);
    }
}
