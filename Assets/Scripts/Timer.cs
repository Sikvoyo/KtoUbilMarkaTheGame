using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTimeInSeconds = 10f*60f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Music music;

    float timeInSeconds;

    public float TimeInSeconds
    {
        get {return timeInSeconds;}
    }

    private void Awake() 
    {
        ProcessSingelton();
        timeInSeconds = startTimeInSeconds;
        StartCoroutine(UpdateTimer());

    }

    IEnumerator UpdateTimer()
    {
        while (timeInSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            timeInSeconds--;
            timerText.text = ConvertNumberToTime(timeInSeconds);

            CheckIfTimeIsOut();
        }
    }

    private void CheckIfTimeIsOut()
    {
        if (timeInSeconds <= 0)
        {
            Music music = FindObjectOfType<Music>();
            music.audioSource.Stop();
            music.playFootsteps = false;
            FindObjectOfType<KUMSceneManager>().LoadScene("KtoUbil");
            Destroy(gameObject);
        }
    }

    private string ConvertNumberToTime(float num)
    {
        float minutes = Mathf.FloorToInt(num / 60f);
        float seconds = num - minutes * 60f;

        return $"{AddZero(minutes.ToString())}:{AddZero(seconds.ToString())}";
    }

    private string AddZero(string number)
    {
        if (number.Length == 1)
        {
            return "0" + number;
        }
        else
        {
            return number;
        }
    }

    private void ProcessSingelton()
    {
        if (FindObjectsOfType<Music>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
