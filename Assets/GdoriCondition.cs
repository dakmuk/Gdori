using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GdoriCondition : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public bool isDead;
    public UnityEvent onGdoriRespawn;
    public UnityEvent onGdoriDie;
    public GameObject panel;
    public int score;
    CapsuleCollider2D capsuleCollider;
    public UnityEvent<int> onScore;

    void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        score = 0;
    }

    void Update()
    {
        var hit = Physics2D.Raycast(transform.position, transform.forward, 0.0f, 128 );
        var score = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.extents, 0.0f, Vector2.zero, 0.0f, 256);
        if(!isDead && hit)
        {
            GdoriDead();
        }
        if (score)
        {
            score.transform.gameObject.GetComponent<TokenRespawn>().Collected();
            GdoriScore();
        }

    }

    public void GdoriDead()
    {
        animator.SetTrigger("die");
        onGdoriDie.Invoke();
        isDead = true;
        this.transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        Invoke("GdoriRespawn", 4.0f);
    }

    private void GdoriRespawn()
    {
        onGdoriRespawn.Invoke();
        animator.SetTrigger("respawn");
    }

    private void GdoriScore()
    {
        score++;
        onScore.Invoke(score);
    }
}
