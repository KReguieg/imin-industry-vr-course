using UnityEngine;

[System.Serializable]
public class Room0State : IState
{
    private string stateName;

    public Room0State()
    {
        this.stateName = typeof(Room0State).Name;
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
