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
        oprosnikiManager.ChangeCharacter(myCharacter);
    }
}
