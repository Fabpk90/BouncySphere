﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.levelLoading = SceneManager.LoadSceneAsync(PlayerData.playerData.currentLevel);	
	}
}
