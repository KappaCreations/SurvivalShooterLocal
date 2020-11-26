using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dramaticZoom : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    public IEnumerator DramaticZoom (float duration, float intensity)
    {

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            cam.orthographicSize += intensity;

            yield return null;
        }

    }
}
