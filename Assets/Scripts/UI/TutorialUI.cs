using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialUI : MonoBehaviour
{
    private void Start()
    {
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Show();
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        // Oyuncu Interact'e basýnca tutorial kapanýr
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
