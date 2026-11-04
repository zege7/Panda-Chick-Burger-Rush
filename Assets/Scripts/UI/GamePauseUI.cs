using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeBotton;
    [SerializeField] private Button mainMenuBotton;

    private void Awake()
    {
        resumeBotton.onClick.AddListener(() =>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuBotton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        Hide();
    }
    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Show()
    {      
        gameObject.SetActive(true);
        resumeBotton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
