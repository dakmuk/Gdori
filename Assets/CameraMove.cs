using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float gain;
    GameObject Gdori;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        Gdori = GameObject.Find("Gdori");
    }

    // Update is called once per frame
    void Update()
    {
        target = Gdori.transform.position;
    }
}
