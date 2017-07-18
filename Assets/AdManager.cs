
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour {

    private BannerView bannerView;

	// Use this for initialization
	void Start () {

        
	}

    private void OnEnable()
    {
        showBannerAd();
    }

    private void OnDisable()
    {
        bannerView.Hide();
    }

    private void OnDestroy()
    {
        bannerView.Destroy();
    }

    private void showBannerAd()
    {
        string adID = "ca-app-pub-5899990337622125/8282891899";

        //***For Testing in the Device***
        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        .AddTestDevice(SystemInfo.deviceUniqueIdentifier)  // My test device.
        .Build();

        bannerView = new BannerView(adID, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
       // AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
