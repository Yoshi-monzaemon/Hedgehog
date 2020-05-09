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
    private GameObject[] mushiTachi;
    private Camera mainCamera;
    private Rect rect = new Rect(0, 0, 1, 1);

    float horizontalKey;
    bool jumpswitch = false;
    bool s_pushed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpswitch = true;
        horizontalKey = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.S)) s_pushed = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }

        transform.Translate(Input.GetAxisRaw("Horizontal") * movespeed * Time.deltaTime, 0, 0);

        isGround = ground.IsGround();

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

            if (jumpswitch)
            {
                jumpswitch = false;
                jumpcount = 0;
                Jump();
            }
        }
        else if (jumpswitch)
        {
            jumpswitch = false;
            if (jumpcount <= 1) Jump();
        }

        if(s_pushed)
        {
            s_pushed = false;
            SearchMushiKun();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            mushi_Capture_Counter++;
        }

    }

    private void Jump()
    {
        this.rb.AddForce(transform.up * jumpPower);
        jumpcount++;
    }

    // メソッド名の命名規則が統一できていない。  
    // Unityは基本キャメルケースで書いてあるのでそちらに揃える
    private void SearchMushiKun()
    {
        int i = 1;
        mushiTachi = GameObject.FindGameObjectsWithTag("Feed");
        foreach(GameObject mushi in mushiTachi)
        {
            var viewportPos = mainCamera.WorldToViewportPoint(mushi.transform.position);
            if (rect.Contains(viewportPos))
            {
                Debug.Log(i + ":カメラに入っています");
            }
            else
            {
                Debug.Log(i + ":カメラに入っていません");
            }
            i++;
        }
    }
}
