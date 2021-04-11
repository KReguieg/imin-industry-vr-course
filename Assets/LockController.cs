using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class LockController : MonoBehaviour
{

    public List<TMP_Text> numbersText = new List<TMP_Text>();

    public float numberSpeed;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void StartAdding(int index)
    {
        StartCoroutine(StartCountingRoutine(index, 1));
    }

    public void StartSubtracking(int index)
    {
        StartCoroutine(StartCountingRoutine(index, -1));

    }

    public void StopCounting()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartCountingRoutine(int index, int amount)
    {
        while (true)
        {
            yield return new WaitForSeconds(numberSpeed);

            int newNumber = amount + int.Parse(numbersText[index].text);

            newNumber = newNumber > 9 ? 0 : newNumber;
            newNumber = newNumber < 0 ? 9 : newNumber;

            numbersText[index].text = newNumber.ToString();
            audioSource.Play();
        }
    }
}
