using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class LockController : MonoBehaviour
{
    public UnityEvent OnPasswordUnlocked;

    public List<TMP_Text> numbersText = new List<TMP_Text>();

    public List<int> password = new List<int>();
    private List<int> currentCombination = new List<int>{ 0, 0, 0 };

    public float numberSpeed;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

            currentCombination[index] = newNumber;

            if (CheckIfValidPassword(currentCombination))
                OnPasswordUnlocked.Invoke();
                
        }
    }

    private bool CheckIfValidPassword(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] != password[i])
                return false;
        }

        return true;
    }
}
