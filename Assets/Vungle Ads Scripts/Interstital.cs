using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Interstital : MonoBehaviour
{
    public string interstitalID = "";
    Action callbackAction = null;
    private bool isShowDebuge = false;

    public void inilizationComplete(bool isShowDebuge)
    {
        this.isShowDebuge = isShowDebuge;
        addEvent();
        loadAd();
    }
     void loadAd()
    {
        Vungle.loadAd(interstitalID);
    }

    public void showAd()
    {
        if (removeAds() == 1)
            return;
        if (Vungle.isAdvertAvailable(interstitalID))
        {
            Vungle.playAd(interstitalID);
        }
        else
            loadAd();
    }
    public void showAd(Action callback)
    {
        if (removeAds() == 1 && callback != null)
        {
            callback.Invoke();
            return;
        }

        if (Vungle.isAdvertAvailable(interstitalID))
        {
            if (callback != null)
                callbackAction = callback;

            Vungle.playAd(interstitalID);
        }
        else
        {
            loadAd();
            if (callback != null)
                callback.Invoke();
        }
    }


    void addEvent()
    {
        Vungle.onAdEndEvent += onAdsClosed;
    }
    void onAdsClosed(string placementid)
    {
        
        if (placementid == interstitalID)
        {
            if(isShowDebuge)
            Debug.Log("Vungle intersitial close ");
            if (callbackAction != null)
            {
                callbackAction.Invoke();
                callbackAction = null;
            }
            loadAd();

        }
    }
   
    int removeAds()
    {
        return PlayerPrefs.GetInt("RemoveAds");
    }


   
}
