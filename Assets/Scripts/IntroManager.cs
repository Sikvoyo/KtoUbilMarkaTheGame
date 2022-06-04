using UnityEngine;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += GoToMainMenu;
    }

    private void GoToMainMenu(VideoPlayer source)
    {
        videoPlayer.loopPointReached -= GoToMainMenu;
        FindObjectOfType<KUMSceneManager>().LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
