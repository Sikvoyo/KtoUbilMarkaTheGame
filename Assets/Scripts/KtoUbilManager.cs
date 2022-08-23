using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Localization.Settings;
using UnityEngine.Playables;
using UnityEngine.UI;

public class KtoUbilManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Transform panelObject;
    [SerializeField] GameObject optionsObject;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject lossScreen;
    [SerializeField] PlayableDirector timeline;
    [SerializeField] AudioClip boomSound;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip lossSound;
    [SerializeField] float shotLength = 5f;
    [SerializeField] KUMSceneManager kUMSceneManager;

    [Space(10)]

    [SerializeField] CharacterObject monokuma;

    [Space(5)]

    [SerializeField] CharacterObject monokumaDialoguesRU;
    [SerializeField] CharacterObject monokumaDialoguesEN;
    [SerializeField] CharacterObject otherDialoguesRU;
    [SerializeField] CharacterObject otherDialoguesEN;
    [SerializeField] Sprite mayorSprite;
    [SerializeField] Sprite win;
    [SerializeField] Sprite loss;


    DialogueSystem dialogueSystem;
    DialogueText dialogueText;
    Vector3 cameraPos;
    HandDrawnEllipse handDrawnEllipse;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ShowOptions;
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        dialogueSystem.OnLastPhrase += HandleDialogueEnd;
        dialogueText = FindObjectOfType<DialogueText>();
        cameraPos = Camera.main.transform.position;

        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
            timer.DestroyMyself();
    }

    private void LoadStart()
    {
        handDrawnEllipse.OnFinishedClick -= LoadStart;
        kUMSceneManager.gameObject.SetActive(true);
        kUMSceneManager.LoadScene("MainMenu");
    }

    private void ShowOptions(VideoPlayer source)
    {
        videoPlayer.loopPointReached -= ShowOptions;
        Destroy(panelObject.gameObject);
        optionsObject.SetActive(true);
        timeline.Play();
        timeline.stopped += EnableButtons;
    }

    private void EnableButtons(PlayableDirector obj)
    {
        foreach (Button button in optionsObject.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
            button.GetComponent<ChoiceButton>().isEnabled = true;
        }
        timeline.stopped -= EnableButtons;
    }

    public void OnOptionChosen(CharacterObject characterObject)
    {
        StartCoroutine(Ending(characterObject));
    }

    private IEnumerator Ending(CharacterObject characterObject)
    {
        optionsObject.SetActive(false);
        AudioSource.PlayClipAtPoint(boomSound, cameraPos);

        yield return new WaitForSeconds(boomSound.length);

        FindObjectOfType<DialogueText>().EnableText();
        if (characterObject == monokuma)
        {
            dialogueSystem.SetNewDialogue(LocalizationSettings.SelectedLocale.name == "English (en)" ? monokumaDialoguesEN : monokumaDialoguesRU);
        }
        else
        {
            dialogueSystem.SetNewDialogue(LocalizationSettings.SelectedLocale.name == "English (en)" ? otherDialoguesEN : otherDialoguesRU);
        }
    }

    private void HandleDialogueEnd()
    {
        AudioSource.PlayClipAtPoint(shotSound, cameraPos, 0.5f);
        dialogueSystem.OnLastPhrase -= HandleDialogueEnd;

        Invoke("ShowEndScreen", shotLength);
    }

    private void ShowEndScreen()
    {
        if (dialogueSystem.CurrentSpeaker == monokumaDialoguesRU || dialogueSystem.CurrentSpeaker == monokumaDialoguesEN)
        {
            winScreen.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, cameraPos, 0.5f);
        }
        else if (dialogueSystem.CurrentSpeaker == otherDialoguesRU || dialogueSystem.CurrentSpeaker == otherDialoguesEN)
        {
            lossScreen.SetActive(true);
            AudioSource.PlayClipAtPoint(lossSound, cameraPos, 0.5f);
        }
        else
        {
            Debug.LogWarning("Чё-то не так");
        }
        // handDrawnEllipse = FindObjectOfType<HandDrawnEllipse>();
        // handDrawnEllipse.OnFinishedClick += LoadStart;
    }
}
