using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] CharacterObject myCharacter;
    
    [Header("Компоненты")]
    [SerializeField] OprosnikiManager oprosnikiManager;

    public void OnButtonPressed()
    {
        Debug.Log("работает");
        oprosnikiManager.ChangeCharacter(myCharacter);
    }
}
