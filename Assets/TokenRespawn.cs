using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenRespawn : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(Random.Range(-5,5), Random.Range(1,7) + 0.5f, 0);
    }
    public void Collected()
    {
        animator.SetTrigger("collect");
        transform.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("Respawn", 2.0f);
    }
    private void Respawn()
    {
        transform.position = new Vector3(Random.Range(-5,5), Random.Range(1,7) + 0.5f, 0);
        transform.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        animator.SetTrigger("respawn");
    }
}
