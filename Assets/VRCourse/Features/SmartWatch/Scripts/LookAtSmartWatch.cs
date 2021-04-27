using UnityEngine;

public class LookAtSmartWatch : MonoBehaviour
{
    [SerializeField] private GameObject displayNormal;
    [SerializeField] private GameObject hologram;
    [Range(-0.5f, -1.0f)]
    [SerializeField] private float lookAtRange = -0.95f;

    private Camera headsetCamera;

    // Start is called before the first frame update
    void Start()
    {
        headsetCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float displayDotCamera = Vector3.Dot(headsetCamera.transform.forward, displayNormal.transform.forward);

        hologram.SetActive(displayDotCamera <= lookAtRange);
    }
}
