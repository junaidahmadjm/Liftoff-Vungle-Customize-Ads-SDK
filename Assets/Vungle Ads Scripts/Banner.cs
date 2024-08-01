using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banner : MonoBehaviour
{
    public string bannerID = "";
    private Vungle.VungleBannerSize _size;
    private Vungle.VungleBannerPosition _position;
    private bool isShowDebuge = false;
    

    public void inilizationComplete(bool isShowDebuge)
    {
        this.isShowDebuge = isShowDebuge;
        
        
    }
    public void loadAd( Vungle.VungleBannerSize size,Vungle.VungleBannerPosition position)
    {
        Vungle.loadBanner(bannerID,size,position);
        _size = size;
        _position = position;
    }

   public void showBanner(Vungle.VungleBannerSize size, Vungle.VungleBannerPosition position)
    {
        if (removeAds() == 1)
            return;
        if (Vungle.isAdvertAvailable(bannerID, size))
        {
            Vungle.showBanner(bannerID);
        }
        else
        {
            if (isShowDebuge)
                Debug.Log("banner is loading...");
            loadAd(size, position);
            Vungle.showBanner(bannerID);
        }
    }
    public void hidebanner()
    {
        Vungle.closeBanner(bannerID);
    }

    int removeAds()
    {
        return PlayerPrefs.GetInt("RemoveAds");
    }
}
