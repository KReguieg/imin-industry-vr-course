using UnityEngine;

public class Room1State : IState
{
    private string stateName;

    public Room1State()
    {
        this.stateName = typeof(Room1State).Name;
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
