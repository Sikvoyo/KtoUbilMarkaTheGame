using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KUMSceneManager : MonoBehaviour
{
    [SerializeField] float transitionTime = 0.5f;

    [SerializeField] Animator blackoutAnimator;

    public void LoadScene(string sceneName)
    {
        Music music = FindObjectOfType<Music>();
        if (music)
            music.PlayFootsteps();
            
        StartCoroutine(LoadAnimation(sceneName));
    }

    private IEnumerator LoadAnimation(string sceneName)
    {
        blackoutAnimator.SetTrigger("startBlackout");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
