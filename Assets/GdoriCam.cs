using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GdoriCam : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void NewFollow(GameObject gdori)
    {
        vcam.Follow = gdori.transform;
        vcam.LookAt = gdori.transform;
    }
}
