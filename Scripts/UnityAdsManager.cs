using System;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityAdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static UnityAdsManager Instance;

    public string GAME_ID = "5370894"; 
    private const string BANNER_PLACEMENT = "Banner_Android";
    private const string VIDEO_PLACEMENT = "Interstitial_Android";
    private const string REWARDED_VIDEO_PLACEMENT = "Rewarded_Android";

    [SerializeField] private BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    private bool testMode = false;
    private bool showBanner = false;

    //utility wrappers for debuglog
    public delegate void DebugEvent(string msg);
    public static event DebugEvent OnDebugLog;

    private void Awake()
    {
        Instance = this;
        Initialize();
    }
    private void Start()
    {
      
        LoadRewardedAd();
    }
    public void Initialize()
    {
        print("Initialize");
        if (Advertisement.isSupported)
        {
            print(Application.platform + " supported by Advertisement");
        }
        Advertisement.Initialize(GAME_ID, testMode, this);
    }

    public void ToggleBanner()
    {
        showBanner = !showBanner;

        if (showBanner)
        {
            Advertisement.Banner.SetPosition(bannerPosition);
            Advertisement.Banner.Show(BANNER_PLACEMENT);
        }
        else
        {
            Advertisement.Banner.Hide(false);
        }
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(REWARDED_VIDEO_PLACEMENT, this);

        print("LoadRewardedAd");
    }

    public void ShowRewardedAd()
    {

        Advertisement.Show(REWARDED_VIDEO_PLACEMENT, this);
        print("ShowRewardedAd");
        LoadRewardedAd();
    }

    public void LoadNonRewardedAd()
    {
        Advertisement.Load(VIDEO_PLACEMENT, this);
    }

    public void ShowNonRewardedAd()
    {
        Advertisement.Show(VIDEO_PLACEMENT, this);
    }

    #region Interface Implementations
    public void OnInitializationComplete()
    {
        // DebugLog("Init Success");
        print("OnInitializationComplete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
         Debug.Log($"Init Failed: [{error}]: {message}");
        //print("bhanu");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        // DebugLog($"Load Success: {placementId}");
        print("OnUnityAdsAdLoaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Load Failed: [{error}:{placementId}] {message}");
        print("OnUnityAdsFailedToLoad");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"OnUnityAdsShowFailure: [{error}]: {message}");
        print("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        // DebugLog($"OnUnityAdsShowStart: {placementId}");
        print("OnUnityAdsShowStart");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        // DebugLog($"OnUnityAdsShowClick: {placementId}");
        print("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("OnUnityAdsShowComplete");
    }
    #endregion

    public void OnGameIDFieldChanged(string newInput)
    {
        GAME_ID = newInput;
    }

    public void ToggleTestMode(bool isOn)
    {
        testMode = isOn;
    }

    //wrapper around debug.log to allow broadcasting log strings to the UI
    //void DebugLog(string msg)
    //{
    //    OnDebugLog?.Invoke(msg);
    //    Debug.Log(msg);

}
