using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Collider roomDCollider;
    [SerializeField] private GameObject robot;

    public UnityEvent OnEnteredRoomD;

    private DeathCountdown deathCountdown;
    private RobotSoundManager robotSoundManager;

    void Start()
    {
        deathCountdown = FindObjectOfType<DeathCountdown>();
        robotSoundManager = FindObjectOfType<RobotSoundManager>();
    }

    void Update()
    {
        
    }

    public void StartMainGame()
    {
        deathCountdown.StartCountdown();
        robotSoundManager.SetRoom(3);
        Debug.Log("main game");
    }
}
