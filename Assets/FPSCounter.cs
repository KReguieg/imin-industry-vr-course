using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private TMP_Text fpsTextField = null;

    private float frameTime = 0.0f;
    private float fps = 0.0f;
    private float fpsTimer = 0.0f;
    private int fpsCounter = 0;

    private void Start()
    {
        fpsTextField = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.frameTime = Time.unscaledDeltaTime;

            fpsCounter++;
            fpsTimer += this.frameTime;
            if (this.fpsTimer > 1.0f)
            {
                this.fps = (float)this.fpsCounter / this.fpsTimer;
                this.fpsTimer -= 1.0f;
                this.fpsCounter = 0;
            }

            fpsTextField.text = string.Format("{0:F} FPS", this.fps);
        }
    }
}
