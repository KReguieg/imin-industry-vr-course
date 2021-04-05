using UnityEngine;

public class Room2State : IState
{
    private string stateName;

    public Room2State()
    {
        this.stateName = typeof(Room2State).Name;
    }

    public void EnterState()
    {
        Debug.LogFormat(">>>>> Entering {0} State <<<<<", stateName);
    }

    public void ExecuteState()
    {
        Debug.LogFormat(">>>>> Executing {0} State <<<<<", stateName);
    }

    public void ExitState()
    {
        Debug.LogFormat(">>>>> Exiting {0} State <<<<<", stateName);
    }
}
