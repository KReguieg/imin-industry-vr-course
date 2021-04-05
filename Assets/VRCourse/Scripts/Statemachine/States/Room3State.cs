using UnityEngine;

public class Room3State : IState
{
    private string stateName;

    public Room3State()
    {
        this.stateName = typeof(Room3State).Name;
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
