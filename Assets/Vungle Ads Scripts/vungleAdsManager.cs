using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class vungleAdsManager : MonoBehaviour
{
    [SerializeField]
    private bool isShowDebug = false;
    [SerializeField]
    private string appID = "";
    [SerializeField]
    private Interstital _inter;
    [SerializeField]
    private Rewarded _rewarded;
    [SerializeField]
    private Banner _banner;
    [SerializeField]
    private BigBanner _bigBanner;

    public static vungleAdsManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        Vungle.init(appID);
        Vungle.onInitializeEvent += onInitialization_SDK;
    }


    void onInitialization_SDK()
    {

        if(isShowDebug)
        Debug.Log("Vungle SDK Initialized Successfully");

        _inter.inilizationComplete(isShowDebug);

        _rewarded.inilizationComplete(isShowDebug);
        _banner.inilizationComplete(isShowDebug);
        _bigBanner.inilizationComplete(isShowDebug);
    }

    public void showInterstitial()
    {
        _inter.showAd();
    }
    public void showInterstitial(Action callback)
    {
        _inter.showAd(callback);
    }
    public void showRewarded(Action callback)
    {
        _rewarded.showAd(callback);
    }

    public void showBanner(Vungle.VungleBannerSize size,Vungle.VungleBannerPosition position)
    {
        _banner.showBanner(size,position);
    }
    public void showBigBanner(Vungle.VungleBannerSize size, Vungle.VungleBannerPosition position)
    {
        _bigBanner.showBanner(size, position);
    }

    public void hideBanner()
    {
        _banner.hidebanner();
    }
    public void hideBigBanner()
    {
        _bigBanner.hidebanner();
    }
}
