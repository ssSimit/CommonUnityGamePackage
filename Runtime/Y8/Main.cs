using UnityEngine;
public class Main : MonoBehaviour
{
    public void showAd()
    {
        Debug.Log("showAd");
        AfgbetaJs.InterstialAd();
    }

    public void showRewardAd()
    {
        Debug.Log("showRewardAd");
        AfgbetaJs.rewardAds();
    }

    public void pauseGame()
    {
        MusicManager.Instance.PauseMute(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        MusicManager.Instance.PauseMute(false);
        Time.timeScale = 1f;
    }
    public void rewardAdsCompleted()
    {
        //  Debug.Log("rewardAdsCompleted");
        //  Debug.Log("This fucntion will triger if the user watched the ads completely, we should give the rewards here");
        AdsManager.Instance.OnRewardedAdCompleted.Invoke();
    }

    public void rewardAdsCanceled()
    {
        //  Debug.Log("rewardAdsCanceled");
        //  Debug.Log("This fucntion will triger if the user cancel the ads before the ads completed");
        AdsManager.Instance.OnRewardedAdCanceled.Invoke();
    }

    public void NoRewardedAdsTryLater()
    {
        // Debug.Log("NoRewardedAdsTryLater");
        // Debug.Log("This fucntion will triger if theer is no ads right now");
        resumeGameRewarded();
        AdsManager.Instance.OnNoRewardedAdAvailable.Invoke();
    }

    public void resumeGameRewarded()
    {
        Time.timeScale = 1f;
        MusicManager.Instance.PauseMute(false);
    }
}
