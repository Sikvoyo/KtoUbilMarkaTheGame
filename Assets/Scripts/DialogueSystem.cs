using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI whoSaysText;
    [SerializeField] TextMeshProUGUI phraseText;
    [SerializeField] GameObject continueArrow;

    [SerializeField] string mainCharacterName = "Детектив Павел";
    [SerializeField] float typingSpeed = 0.2f;

    int currentPhraseIndex = 0;
    bool canContinue = true;

    CharacterObject currentSpeaker;
    OprosnikiManager oprosnikiManager;
    DialogueText dialogueText;

    public event Action OnLastPhrase;

    public CharacterObject CurrentSpeaker
    {
        get { return currentSpeaker; }
    }

    private void Start() 
    {
        oprosnikiManager = GetComponent<OprosnikiManager>();
        dialogueText = FindObjectOfType<DialogueText>();
    }

    private void Update() {
        continueArrow.SetActive(canContinue);
    }

    public void SetNewDialogue(CharacterObject newSpeaker)
    {
        currentSpeaker = newSpeaker;
        currentPhraseIndex = 0;
        UpdateText();
    }

    public void NextPhrase()
    {
        if (!canContinue) return;

        if (currentPhraseIndex + 1 == currentSpeaker.dialogue.Count)
        {
            OnLastPhrase?.Invoke();
            dialogueText.DisableText();
            return;
        }

        currentPhraseIndex++;
        UpdateText();
    }

    private void UpdateText()
    {
        phraseText.text = null;
        bool doTheySpeak = currentSpeaker.dialogue[currentPhraseIndex].doISayThat;
        string whatDoTheySay = currentSpeaker.dialogue[currentPhraseIndex].phrase;

        UpdateCharacterName(currentSpeaker, doTheySpeak);

        StartCoroutine(Type(whatDoTheySay));
    }

    private IEnumerator Type(string whatToType)
    {
        canContinue = false;
        foreach (char letter in whatToType)
        {
            phraseText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinue = true;
    }

    private void UpdateCharacterName(CharacterObject characterSpeaking, bool doTheySpeak)
    {
        if (doTheySpeak)
        {
            whoSaysText.text = characterSpeaking.characterName;
        }
        else
        {
            whoSaysText.text = mainCharacterName;
        }
    }
}
