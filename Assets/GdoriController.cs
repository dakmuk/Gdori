using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GdoriController : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayerMask;
    Animator animator;
    new Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    BoxCollider2D boxCollider;
    GdoriCondition GdoriCondi;
    public float jumpPower;
    public float runSpeed;
    public int maxJumpCount;
    public int currentJumpCount;
    private bool isSprinting;

    public UnityEvent onJump;
    public UnityEvent onSprint;
    public UnityEvent onEnd;

    public bool end;
    public GameObject timer;
    private Countdown cd;
    private float temptime;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        GdoriCondi = GetComponent<GdoriCondition>();
        isSprinting = false;
        end = false;
        cd = timer.GetComponent<Countdown>();
        temptime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GdoriLand");
        }
        if (Time.time - temptime >= 1 && !end)
        {
            cd.updateTimer();
            temptime = Time.time;
        }

        if (Time.time > 60.0f && !end)
        {
            end = true;
            rigidbody.velocity = Vector3.zero;
            animator.SetTrigger("end");
            onEnd.Invoke();
        }
        if (!GdoriCondi.isDead && !end)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (currentJumpCount < maxJumpCount)
                {
                    if (currentJumpCount == 0)
                    {
                        animator.SetTrigger("doJumping");
                        animator.SetBool("isJumping", true);
                    }
                    else
                    {
                        animator.SetTrigger("doDoubleJumping");
                        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, 0);
                    }
                    //rigidbody.velocity = Vector2.up * jumpPower;
                    rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    onJump.Invoke();
                    currentJumpCount++;
                }
            }
            //if (Input.GetButtonUp("Horizontal"))
            //{
            //    animator.SetBool("isRunning", false);
            //}
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    animator.SetBool("isRunning", true);
                    rigidbody.velocity = new Vector2(runSpeed * (isSprinting ? 2.0f : 1.0f), rigidbody.velocity.y);
                    //rigidbody.AddForce(Vector2.right * runSpeed * (isSprinting ? 1.5f : 1.0f) - rigidbody.velocity, ForceMode2D.Force);
                }
                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    animator.SetBool("isRunning", true);
                    rigidbody.velocity = new Vector2(-runSpeed * (isSprinting ? 2.0f : 1.0f), rigidbody.velocity.y);
                    //rigidbody.AddForce(Vector2.left * runSpeed * (isSprinting ? 1.5f : 1.0f) - rigidbody.velocity, ForceMode2D.Force);
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }
            if (Input.GetButtonDown("Fire3"))
            {
                animator.SetBool("isSprinting", true);
                onSprint.Invoke();
                isSprinting = true;
            }
            if (Input.GetButtonUp("Fire3"))
            {
                animator.SetBool("isSprinting", false);
                isSprinting = false;
            }
            rigidbody.rotation = 0;


            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0.0f, Vector2.down, .05f, groundLayerMask);
            if (raycastHit.collider != null && rigidbody.velocity.y <= 0)
            {
                animator.SetBool("isJumping", false);
                currentJumpCount = 0;
            }
        }
    }
}
