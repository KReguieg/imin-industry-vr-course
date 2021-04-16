using UnityEngine;

public class FadeRayCaster : MonoBehaviour
{
    [SerializeField] SpriteRenderer headFadeSprite = null;
    [SerializeField] LayerMask collisionLayerMask = new LayerMask();
    [SerializeField] Color fadeColor = Color.white;
    [SerializeField] Color nonFadeColor = Color.white;
    [SerializeField] float proximity;

    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << collisionLayerMask.value;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.distance < 0.25f)
            {
                Debug.Log("hitdistance= " + hit.distance);
                Debug.Log("Clamp= " + Mathf.Clamp01(hit.distance));
                Debug.Log("InverseLerp " + Mathf.InverseLerp(1, 0, hit.distance * 10));
                float fadeValue = Mathf.InverseLerp(5, 0, hit.distance * 10);
                fadeColor.a = fadeValue;
                headFadeSprite.color = fadeColor;
            }
            else
            {
                fadeColor = nonFadeColor;
                headFadeSprite.color = nonFadeColor;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            fadeColor = nonFadeColor;
            headFadeSprite.color = nonFadeColor;
        }
    }
}
