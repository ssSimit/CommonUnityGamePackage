using UnityEngine;
using System.Runtime.InteropServices;

public class AfgbetaJs : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void InterstialAd();

    [DllImport("__Internal")]
    public static extern void rewardAds();

    public void ShowInterstialAd()
    {
        // Calling JS function
        Debug.Log("ShowInterstialAd");
        InterstialAd();
    }

    public void ShowRewardedAds()
    {
        // Calling JS function
        Debug.Log("ShowRewardedAds");
        rewardAds();
    }
}