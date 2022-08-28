using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    const string domScene = "Dom";
    const string dorogaScene = "Doroga";
    const string oprosnikiScene = "Oprosniki";

    KUMSceneManager kUMSceneManager;

    private void Awake() {
        kUMSceneManager = FindObjectOfType<KUMSceneManager>();
    }

    public void GoToRoomA()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case domScene:
                kUMSceneManager.LoadScene(dorogaScene);
                break;
            case oprosnikiScene:
                kUMSceneManager.LoadScene(domScene);
                break;
            default:
                return;
        }
    }

    public void GoToRoomB()
    {
        if (SceneManager.GetActiveScene().name == domScene)
        {
            kUMSceneManager.LoadScene(oprosnikiScene);
        }
        else if (SceneManager.GetActiveScene().name == dorogaScene)
        {
            kUMSceneManager.LoadScene(domScene);
        }
    }
    
    public void JumpToTheVote()
    {
        Music music = FindObjectOfType<Music>();
        music.audioSource.Stop();
        music.playFootsteps = false;
        FindObjectOfType<KUMSceneManager>().LoadScene("KtoUbil");
    }

    public void QuitGame() 
    {
        Debug.Log("вышли!");
        Application.Quit();
    }
}
