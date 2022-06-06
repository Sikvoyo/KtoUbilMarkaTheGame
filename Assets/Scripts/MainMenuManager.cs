using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string explainSceneName = "Explain";
    [SerializeField] HandDrawnEllipse handDrawnEllipse;

    private void Start() 
    {
        handDrawnEllipse.OnFinishedClick += StartGame;
    }

    public void StartGame()
    {
        handDrawnEllipse.OnFinishedClick -= StartGame;
        FindObjectOfType<KUMSceneManager>().LoadScene(explainSceneName);
    }
}
