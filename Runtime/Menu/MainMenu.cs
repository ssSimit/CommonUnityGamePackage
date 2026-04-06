using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private int gameSceneIndex = 1;

    [Header("1 Player Buttons")]
    [SerializeField] private Button playBtn;

    [Header("2 Player Buttons")]
    [SerializeField] private Button botPlayBtn;
    [SerializeField] private Button frnPlayBtn;

    [Header("Panel References")]
    [SerializeField] private CanvasGroup transitionCanvasGroup;

    private void Start()
    {
        playBtn.onClick.AddListener(OnPlayButtonClicked);
        botPlayBtn.onClick.AddListener(OnBotPlayButtonClicked);
        frnPlayBtn.onClick.AddListener(OnFrnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        StartCoroutine(TransitionToScene(gameSceneIndex));
    }

    private void OnBotPlayButtonClicked()
    {
        GlobalGameManager.Instance.SetGameMode(GameMode.VsBot);
        StartCoroutine(TransitionToScene(gameSceneIndex));
    }

    private void OnFrnPlayButtonClicked()
    {
        GlobalGameManager.Instance.SetGameMode(GameMode.VsFriend);
        StartCoroutine(TransitionToScene(gameSceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex)
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transitionCanvasGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }

    public void ButtonClickSound()
    {
        MusicManager.Instance.PlayAudio("btn");
    }

}
