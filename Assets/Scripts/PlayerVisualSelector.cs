using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualSelector : MonoBehaviour
{
    [SerializeField] private GameObject chickVisual;   
    [SerializeField] private GameObject pandaVisual;  

    private void Start()
    {
        // 1. Hafýzadaki seçimi oku (0: chick, 1: Panda)
        int secim = CharacterSelectionData.SelectedCharacterIndex;

        // 2. Duruma göre birini aç, diðerini kapat
        if (secim == 1)
        {
            // PANDA SEÇÝLDÝ
            chickVisual.SetActive(false);
            pandaVisual.SetActive(true);
        }
        else
        {
            // chick SEÇÝLDÝ (veya varsayýlan)
            chickVisual.SetActive(true);
            pandaVisual.SetActive(false);
        }
    }

}
