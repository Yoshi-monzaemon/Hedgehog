using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float dashspeed = 0;
    public GroundCheck ground;
    public float jumpPower = 300f;

    private Rigidbody2D rb = null;
    private bool isGround = true;
    private float movespeed = 0;
    private string enemyTag = "Feed";
    private int jumpcount = 0;
    private int mushi_Capture_Counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        isGround = ground.IsGround();
        float horizontalKey = Input.GetAxis("Horizontal");
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }

        transform.Translate(Input.GetAxisRaw("Horizontal") * movespeed * Time.deltaTime, 0, 0);

        if (isGround)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                movespeed = dashspeed;
            }
            else
            {
                movespeed = speed;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpcount = 0;
                Jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpcount <= 1)
            {
                Jump();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Debug.Log("えさだ");
            mushi_Capture_Counter++;
        }

    }

    private void Jump()
    {
        this.rb.AddForce(transform.up * jumpPower);
        jumpcount++;
    }
}
