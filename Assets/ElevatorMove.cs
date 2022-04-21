using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * Time.deltaTime * speed;
        if (transform.position.y < 0) transform.position += new Vector3(0.0f, 7.0f, 0.0f);
        if (transform.position.y > 7) transform.position -= new Vector3(0.0f, 7.0f, 0.0f);
    }
}
