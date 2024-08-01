using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAds : MonoBehaviour
{
   public void showInter()
    {
        vungleAdsManager.Instance?.showInterstitial();
    }
    public void showInterwithcallback()
    {
        vungleAdsManager.Instance?.showInterstitial(onIntersitialComplete);
    }
    void onIntersitialComplete()
    {
        Debug.Log("Intersitial complete from demo");
    }
    public void showRewarded()
    {
        vungleAdsManager.Instance?.showRewarded(Onrewardedcomlete);
    }
    void Onrewardedcomlete()
    {
        Debug.Log("Rewarded complete from demo");
    }
    public void showBanner()
    {
        vungleAdsManager.Instance?.showBanner(Vungle.VungleBannerSize.VungleAdSizeBanner,Vungle.VungleBannerPosition.TopCenter);
    }
    public void showBigBanner()
    {
        vungleAdsManager.Instance?.showBigBanner(Vungle.VungleBannerSize.VungleAdSizeBannerMedium, Vungle.VungleBannerPosition.BottomRight);
    }
    public void hideBanner()
    {
        vungleAdsManager.Instance?.hideBanner();
    }
    public void hideBigBanner()
    {
        vungleAdsManager.Instance?.hideBigBanner();
    }
}
