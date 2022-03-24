using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    public string _gameID = "4124749";
    public string _bannerID = "banner";
    public string _interstitialID = "interstitial";
    public string _rewardedID = "rewardedVideo";

    public bool TestMode;
    public bool ShowBanner;

    void Start()
    {
        Advertisement.Initialize(_gameID,TestMode);
        Advertisement.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void show_Interstitial()
    {
        if(Advertisement.IsReady(_interstitialID))
        {
            Advertisement.Show(_interstitialID);
            Debug.Log("interstitial");
        }
    }


    public void show_rewarded_video_ad()
    {
        Advertisement.Show(_rewardedID);
        Debug.Log("interstitial");
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
       if(placementId==_bannerID && ShowBanner == true)
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(_bannerID);
            Debug.Log("interstitial");
        }
    }
}
