using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameUIManager : MonoBehaviour
{
    [Header("Button References")]
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button playAgainBtn;
    [SerializeField] private Button[] mainMenuBtn;

    [Header("Panel References")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI winnerText;


    void Start()
    {
        pauseBtn.onClick.AddListener(OnPauseButtonClicked);
        resumeBtn.onClick.AddListener(OnResumeButtonClicked);
        restartBtn.onClick.AddListener(OnRestartButtonClicked);
        playAgainBtn.onClick.AddListener(OnPlayAgainButtonClicked);
        foreach (Button btn in mainMenuBtn)
        {
            btn.onClick.AddListener(OnMainMenuButtonClicked);
        }
        CheckForAds();
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    private void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void OnPlayAgainButtonClicked()
    {
        Time.timeScale = 1f;
        AdsManager.Instance.GamePlayedCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator ShowGameOverPanelWithDelay(float delay, string winnerName = "")
    {
        yield return new WaitForSeconds(delay);
        if (!string.IsNullOrEmpty(winnerName)) winnerText.text = $"{winnerName} Wins!";
        gameOverPanel.SetActive(true);
    }

    void CheckForAds()
    {
        if (AdsManager.Instance.GamePlayedCount == 0 || AdsManager.Instance.GamePlayedCount % 3 == 0)
        {
            AdsManager.Instance.ShowInterstitialAd();
        }
    }

    public void ButtonClickSound()
    {
        MusicManager.Instance.PlayAudio("btn");
    }

}
