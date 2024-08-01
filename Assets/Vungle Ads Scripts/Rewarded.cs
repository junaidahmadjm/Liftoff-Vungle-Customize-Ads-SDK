using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rewarded : MonoBehaviour
{
    public string rewardedID = "";
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
        Vungle.loadAd(rewardedID);
    }

    public void showAd()
    {
        if (removeAds() == 1)
            return;
        if (Vungle.isAdvertAvailable(rewardedID))
        {
            Vungle.playAd(rewardedID);
        }
        else
            loadAd();
    }
    public void showAd(Action callback)
    {
        if (removeAds() == 1)
        {
            
            return;
        }

        if (Vungle.isAdvertAvailable(rewardedID))
        {
            if (callback != null)
                callbackAction = callback;

            Vungle.playAd(rewardedID);
        }
        else
        {
            loadAd();
           
        }
    }


    void addEvent()
    {
        Vungle.onAdEndEvent += onAdsClosed;
        Vungle.onAdRewardedEvent += onRewardeComplete;
    }
    void onAdsClosed(string placementid)
    {

        if (placementid == rewardedID)
        {
            if (isShowDebuge)
                Debug.Log("Vungle rewarded close");
            loadAd();

        }
    }
    void onRewardeComplete(string placementid)
    {

        if (placementid == rewardedID)
        {
            if (isShowDebuge)
                Debug.Log("Vungle reward given");
            if (callbackAction != null)
            {
                callbackAction.Invoke();
                callbackAction = null;
            }


        }
    }

    int removeAds()
    {
        return PlayerPrefs.GetInt("RemoveAds");
    }
}
