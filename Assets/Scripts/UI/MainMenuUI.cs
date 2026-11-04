using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    [Header("Character Selection")]
    [SerializeField] private Button chickSelectButton; 
    [SerializeField] private Button pandaSelectButton; 
    [SerializeField] private GameObject chickSelectedRing; 
    [SerializeField] private GameObject pandaSelectedRing; 
    private void Awake()
    {
        // Oyun açýlýnca varsayýlan olarak Ördek (0) seçili gelsin
        CharacterSelectionData.SelectedCharacterIndex = 0;
        UpdateVisuals();

        //lmbda expressions
        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        // --- KARAKTER SEÇÝM BUTONLARI ---

        // Ördeðe týklandýðýnda
        chickSelectButton.onClick.AddListener(() =>
        {
            CharacterSelectionData.SelectedCharacterIndex = 0; // Hafýzaya 0 yaz
            UpdateVisuals(); // Iþýklarý güncelle

            // Odaðý tekrar Play butonuna veriyoruz
            EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        });

        // Pandaya týklandýðýnda
        pandaSelectButton.onClick.AddListener(() =>
        {
            CharacterSelectionData.SelectedCharacterIndex = 1; // Hafýzaya 1 yaz
            UpdateVisuals(); // Iþýklarý güncelle

            // Odaðý tekrar Play butonuna veriyoruz
            EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        });

        Time.timeScale = 1f; // Ensure time scale is normal when returning to main menu
    }

    private void UpdateVisuals()
    {
        if (CharacterSelectionData.SelectedCharacterIndex == 0)
        {
            // Ördek Seçili: Ördeði yak, Pandayý söndür
            chickSelectedRing.SetActive(true);
            pandaSelectedRing.SetActive(false);
        }
        else
        {
            // Panda Seçili: Ördeði söndür, Pandayý yak
            chickSelectedRing.SetActive(false);
            pandaSelectedRing.SetActive(true);
        }
    }

}
