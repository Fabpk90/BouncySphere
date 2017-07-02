using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelLoaderSlider : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = GameManager.levelLoading.progress;
	}
}
