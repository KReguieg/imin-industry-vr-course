using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DeathCountdown : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int countdownDuration;
    
    public UnityEvent OnCountdownFinished;

    private float secondsLeft;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCountdown();
    }
    public void StartCountdown()
    {
        StartCoroutine(Countdownroutine(countdownDuration));
    }

    private IEnumerator Countdownroutine(int countdownDuration)
    {
        secondsLeft = countdownDuration;
        float minutesLeft;

        while(secondsLeft >= 0)
        {
            audioSource.Play();
            
            secondsLeft--;
            minutesLeft = Mathf.FloorToInt(secondsLeft / 60);

            countdownText.text = string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft % 60);

            yield return new WaitForSeconds(1);
        }

        OnCountdownFinished.Invoke();
    }
}
