using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class GdoriSpawner : MonoBehaviour
{
    public GameObject Gdori;
    GdoriCondition GdoriCondi;
    private void Start()
    {
        GdoriCondi = Gdori.GetComponent<GdoriCondition>();
        Spawn();
    }
    public void Spawn()
    {
        Gdori.transform.position = this.transform.position;
        GdoriCondi.isDead = false;
    }
}
