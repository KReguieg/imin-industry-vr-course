using UnityEngine;

public class Statemachine
{
    private string currentStateName;

    private IState currentState;
    private IState previousState;
    private IState nextState;

    public IState CurrentState { get => currentState; }
    public IState PreviousState { get => previousState; }
    public IState NextState { get => nextState; }


    public string CurrentStateName { get => currentStateName; }

    public Statemachine()
    {
        Debug.Log(">>>> Statemachine created <<<<");
    }

    public void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        previousState = currentState;
        SetCurrentlyRunningState(state);
    }

    private void SetCurrentlyRunningState(IState state)
    {
        currentState = state;
        currentStateName = state.GetType().Name;
        currentState.EnterState();
    }

    public void ExecuteStateUpdate()
    {
        if (currentState != null)
        {
            currentState.ExecuteState();
        }
    }

    public void SwitchToPreviousState()
    {
        ChangeState(previousState);
    }
}