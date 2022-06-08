using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Localization.Settings;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI whoSaysText;
    [SerializeField] TextMeshProUGUI phraseText;
    [SerializeField] GameObject continueArrow;
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> typewriteSounds;

    [SerializeField] string mainCharacterNameRU = "Детектив Павел";
    [SerializeField] string mainCharacterNameEN = "Detective Morbius";
    [SerializeField] float typingSpeed = 0.2f;

    int currentPhraseIndex = 0;
    bool canContinue = true;

    CharacterObject currentSpeaker;
    OprosnikiManager oprosnikiManager;
    DialogueText dialogueText;
    Animator animator;

    public event Action<CharacterObject, int> OnPhraseSaid;
    public event Action OnLastPhrase;

    public CharacterObject CurrentSpeaker
    {
        get { return currentSpeaker; }
    }

    public bool IsTalking
    {
        get { return animator.GetBool("isTalking"); }
    }

    private void Start() 
    {
        oprosnikiManager = GetComponent<OprosnikiManager>();
        dialogueText = FindObjectOfType<DialogueText>();
        animator = dialogueText.GetComponent<Animator>();
    }

    private void Update() {
        continueArrow.SetActive(canContinue);
    }

    public void SetNewDialogue(CharacterObject newSpeaker)
    {
        StopAllCoroutines();

        animator.SetBool("isTalking", true);
        dialogueText.EnableText();
        currentSpeaker = newSpeaker;
        currentPhraseIndex = 0;
        UpdateText();
    }


    public void NextPhrase()
    {
        if (!canContinue) return;

        OnPhraseSaid?.Invoke(currentSpeaker, currentPhraseIndex);

        if (currentPhraseIndex + 1 == currentSpeaker.dialogue.Count)
        {
            OnLastPhrase?.Invoke();
            // dialogueText.DisableText();
            animator.SetBool("isTalking", false);
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
        audioSource.clip = typewriteSounds[UnityEngine.Random.Range(0, typewriteSounds.Count - 1)];
        audioSource.Play();
        canContinue = false;
        foreach (char letter in whatToType)
        {
            phraseText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinue = true;
        audioSource.Stop();
    }

    private void UpdateCharacterName(CharacterObject characterSpeaking, bool doTheySpeak)
    {
        if (doTheySpeak)
        {
            whoSaysText.text = characterSpeaking.characterName;
        }
        else
        {
            whoSaysText.text = LocalizationSettings.SelectedLocale.name == "English (en)" ? mainCharacterNameEN : mainCharacterNameRU;
        }
    }
}
