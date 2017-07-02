using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.levelLoading = SceneManager.LoadSceneAsync(GameManager.currentLevel);	
	}
}
