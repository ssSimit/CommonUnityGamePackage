var AfgbetaJs = {
    InterstialAd: function()
    {
        console.log("InterstialAd");
        showNextAd();
    },
    rewardAds: function()
    {
        console.log("rewardAds");
        showReward();
    }
};

mergeInto(LibraryManager.library, AfgbetaJs);