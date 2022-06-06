using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class PointersCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI rightText;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
 
    
    void Start()
    {
        UpdatePointers();
    }

    private void UpdatePointers()
    {
        bool isEnglish = LocalizationSettings.SelectedLocale.name == "English (en)";
        switch (SceneManager.GetActiveScene().name)
        {
            case "Dom":
                leftText.text = isEnglish ? "Go to the road" : "Выйти на дорогу";
                rightText.text = isEnglish ? "Talk to suspects" : "Допросить подозреваемых";
                break;
            case "Doroga":
                leftButton.SetActive(false);
                rightText.text = isEnglish ? "Enter the house" : "Войти в дом";
                break;
            case "Oprosniki":
                rightButton.SetActive(false);
                leftText.text = isEnglish ? "Leave room" : "Выйти из комнаты";
                break;
        }
    }

    void Update()
    {
        
    }
}
