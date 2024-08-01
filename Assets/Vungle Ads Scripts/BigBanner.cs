using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigBanner : MonoBehaviour
{
    [SerializeField]
    string bigBannerID = "";
    private Vungle.VungleBannerSize _size;
    private Vungle.VungleBannerPosition _position;

    private bool isShowDebuge = false;


    public void inilizationComplete(bool isShowDebuge)
    {
        this.isShowDebuge = isShowDebuge;


    }
    public void loadAd(Vungle.VungleBannerSize size, Vungle.VungleBannerPosition position)
    {
        Vungle.loadBanner(bigBannerID, size, position);
        _size = size;
        _position = position;
    }

    public void showBanner(Vungle.VungleBannerSize size, Vungle.VungleBannerPosition position)
    {
        if (removeAds() == 1)
            return;
        if (Vungle.isAdvertAvailable(bigBannerID, size))
        {
            Vungle.showBanner(bigBannerID);
        }
        else
        {
            if (isShowDebuge)
                Debug.Log("big banner is loading...");
            loadAd(size, position);
            Vungle.showBanner(bigBannerID);
        }
    }
    public void hidebanner()
    {
        Vungle.closeBanner(bigBannerID);
    }

    int removeAds()
    {
        return PlayerPrefs.GetInt("RemoveAds");
    }
}
