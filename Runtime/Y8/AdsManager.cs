using UnityEngine;
using UnityEngine.Events;
public enum RewardType
{
    None
}
public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }
    public RewardType currentRewardType;
    public UnityEvent OnRewardedAdCompleted = new UnityEvent();
    public UnityEvent OnRewardedAdCanceled = new UnityEvent();
    public UnityEvent OnNoRewardedAdAvailable = new UnityEvent();
    public bool interstitialRequestedOnce = false;

    public int GamePlayedCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowInterstitialAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        FindFirstObjectByType<Main>().showAd();

#else
        Debug.Log("Interstitial Ad would show here (Editor mode)");
#endif
    }

    public void ShowRewardedAd(RewardType rewardType)
    {
        currentRewardType = rewardType;
#if UNITY_WEBGL && !UNITY_EDITOR
        FindFirstObjectByType<Main>().showRewardAd();

#else
        Debug.Log("Rewarded Ad would show here (Editor mode)");
        OnRewardedAdCompleted.Invoke(); // Simulate ad completion in editor
#endif
    }


}