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
    private Statemachine statemachine;

    void Start()
    {
        statemachine = new Statemachine();
        statemachine.ChangeState(new Room0State());
        statemachine.ExecuteStateUpdate();

        deathCountdown = FindObjectOfType<DeathCountdown>();
        robotSoundManager = FindObjectOfType<RobotSoundManager>();
    }


    public void StartMainGame()
    {
        deathCountdown.StartCountdown();
        robotSoundManager.SetRoom(3);
        robotSoundManager.PlayNextClip(); 
    }
}
