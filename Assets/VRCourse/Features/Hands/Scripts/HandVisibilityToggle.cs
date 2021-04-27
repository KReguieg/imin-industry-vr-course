using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandVisibilityToggle : MonoBehaviour
{
    private SkinnedMeshRenderer handModel;
    private XRBaseControllerInteractor handInteractor;

    // Start is called before the first frame update
    void Start()
    {
        handModel = GetComponentInChildren<SkinnedMeshRenderer>();
        handInteractor = GetComponentInParent<ActionBasedControllerManager>().GetComponentInChildren< XRBaseControllerInteractor>();

        handInteractor.selectEntered.AddListener(OnGrab);
        handInteractor.selectExited.AddListener(OnLetGo);
    }

    private void OnLetGo(SelectExitEventArgs arg0)
    {
        ToggleHandVisibility();
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        ToggleHandVisibility();
    }

    public void ToggleHandVisibility()
    {
        handModel.enabled = !handModel.enabled;
    }
}
