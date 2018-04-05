using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    public float maxVel = 1f;
    public int frameTravel = 100;
    public bool moveRigth = false;

    private Rigidbody2D rb;
    private Vector2 vel;
    private int frames;


    // Use this for initialization
    void Start () {
        Flip();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        vel = new Vector2(0, rb.velocity.y);
        if (moveRigth)
        {
            vel.x = maxVel;
        }
        else
        {
            vel.x = -maxVel;
        }
        rb.velocity = vel;
        if (frames == frameTravel)
        {
            moveRigth = !moveRigth;
            Flip();
            frames = -1;
        }
        frames++;
    }

    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
