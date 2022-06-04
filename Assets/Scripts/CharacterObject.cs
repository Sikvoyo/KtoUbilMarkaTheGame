using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguePhrase
{
    [TextArea(3, 5)]
    public string phrase;
    public bool doISayThat;
}

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterObject : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;

    public List<DialoguePhrase> dialogue; 

    public CharacterObject(string name, Sprite sprite, List<DialoguePhrase> dialogue)
    {
        this.characterName = name;
        this.characterSprite = sprite;
        this.dialogue = dialogue;
    }
}
