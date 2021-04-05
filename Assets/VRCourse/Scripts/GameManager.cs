using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Collider roomDCollider;
    [SerializeField] private GameObject robot;

    public UnityEvent OnStartGame;

    private DeathCountdown deathCountdown;
    private RobotSoundManager robotSoundManager;

    void Start()
    {
        deathCountdown = FindObjectOfType<DeathCountdown>();
        robotSoundManager = FindObjectOfType<RobotSoundManager>();
    }


    public void StartMainGame()
    {
        deathCountdown.StartCountdown();
        robotSoundManager.SetRoom(3);
        robotSoundManager.PlayNextClip();
        OnStartGame.Invoke();
    }
}
