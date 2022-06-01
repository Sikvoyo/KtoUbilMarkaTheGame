using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string explainSceneName = "Explain";

    public void StartGame()
    {
        SceneManager.LoadScene(explainSceneName);
    }
}
