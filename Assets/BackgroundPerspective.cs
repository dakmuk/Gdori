using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPerspective : MonoBehaviour
{
    public float distance;
    Vector3 origin;
    Vector3 camOrigin;
    void Start()
    {
        origin = transform.position;
        camOrigin = Camera.main.transform.position;

    }
    void Update()
    {
        transform.position = origin + 1 / (1 + 1/(distance > 0.001f ? distance : 0.001f )) * (Camera.main.transform.position - camOrigin);
    }
}
