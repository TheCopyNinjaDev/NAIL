using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AD_Rewarded : ADStore, IUnityAdsListener
{

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    private void Start() 
    {
        Advertisement.Initialize("3803873", false);    
    }

    public void ShowADreward()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }
    }
}