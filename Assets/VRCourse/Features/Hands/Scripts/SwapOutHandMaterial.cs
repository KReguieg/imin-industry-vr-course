using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwapOutHandMaterial : MonoBehaviour
{
    [SerializeField] private Material newHandMaterial;

    public List<Transform> controllers = new List<Transform>();

    private void Start()
    {
        Invoke("GetHandModels", 1.0f);
    }

    void GetHandModels()
    {
        foreach (var controller in FindObjectsOfType<XRBaseController>())
        {
            Debug.Log(controller.name + " " + controller.modelTransform.name);

            if (controller.modelTransform.childCount > 0)
            {
                controllers.Add(controller.modelTransform.GetChild(0));
            }
        }
    }

    SkinnedMeshRenderer gloveSkins;

    public void SwapOutMaterial()
    {
        foreach (var controller in controllers)
        {
            gloveSkins = controller.GetComponentInChildren<SkinnedMeshRenderer>();
            gloveSkins.material = newHandMaterial;
        }

        Destroy(this);
    }
}
