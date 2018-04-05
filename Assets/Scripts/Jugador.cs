using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

    public float maxVel = 5f;
    public float yJumpForce = 300f;

    private Rigidbody2D rb;
    private Vector2 jumpforce;
    private Animator anim;
    private GameObject enemy;
    private bool isJumping = false;
    private bool isWalking = false;
    private bool isCougth = false;
    private bool moveRigth;

    // Use this for initialization
    void Start () {
        Flip();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpforce = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y);

        v *= maxVel;

        if (Input.GetKey("down") && isJumping == false)
        {
            v = 0;
        }

        vel.x = v;

        rb.velocity = vel;

        if (Input.GetAxis("Jump") > 0.1f)
        {
            if (!isJumping)
            {
                if (rb.velocity.y == 0f)
                {
                    anim.SetBool("IsJumping", true);
                    isJumping = true;
                    jumpforce.x = 0f;
                    jumpforce.y = yJumpForce;
                    rb.AddForce(jumpforce);
                }
            }
            else if (rb.velocity.y == 0f)
            {
                anim.SetBool("IsJumping", false);
                isJumping = false;
            }
        }
        else if (rb.velocity.y == 0f)
        {
            anim.SetBool("IsJumping", false);
            isJumping = false;
        }

        if (Input.GetKey("down") && isJumping == false)
        {
            isCougth = true;
            anim.SetBool("IsCougth", true);
        }
        else
        {
            isCougth = false;
            anim.SetBool("IsCougth", false);
        }

        

        if (v != 0 && isCougth == false)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if (moveRigth && v < 0)
        {
            moveRigth = false;
            Flip();
        }
        else if (!moveRigth && v > 0)
        {
            moveRigth = true;
            Flip();
        }
    }

    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        enemy = collider.gameObject;
        if (enemy.layer == 9)
        {
            LifeTracer liveTracer = GameObject.Find("LifeTracer").GetComponent<LifeTracer>();
            liveTracer.Hit();
        }
    }
}
