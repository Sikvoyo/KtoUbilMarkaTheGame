using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTimeInSeconds = 10f*60f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Music music;
    [SerializeField] float whenToStart = 9f*60f+24f+0.6f;

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
    
    void Start()
    {
        Invoke(nameof(StartMusic), startTimeInSeconds - whenToStart);
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
            // Destroy(FindObjectOfType<Music>().gameObject);
            FindObjectOfType<Music>().audioSource.Stop();
            SceneManager.LoadScene("KtoUbil");
            Destroy(gameObject);
        }
    }

    private void StartMusic()
    {
        music.StartMusic();
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
