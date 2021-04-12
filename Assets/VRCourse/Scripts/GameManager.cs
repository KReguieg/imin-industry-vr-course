using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Collider roomDCollider;
    [SerializeField] private GameObject robot;

    [SerializeField] private InputActionReference activateHUD;
    [SerializeField] private GameObject fpsCounter;

    public UnityEvent OnStartGame;

    private DeathCountdown deathCountdown;
    private RobotSoundManager robotSoundManager;
    private Statemachine statemachine;

    private void OnEnable()
    {
        activateHUD.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        fpsCounter.SetActive(!fpsCounter.activeSelf);
    }

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
        OnStartGame.Invoke();
    }

    private void OnDisable()
    {
        activateHUD.action.performed -= Action_performed;
    }
}
