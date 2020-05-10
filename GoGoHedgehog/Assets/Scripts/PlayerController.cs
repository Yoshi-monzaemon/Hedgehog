using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float dashspeed = 0;
    public GroundCheck ground;
    public float jumpPower = 300f;
    public Button rightButton;
    public Button leftButton;
    public Button jumpButton;
    public Button dashButton;
    public Button searchButton;

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
    int s_pushed_counter = 0;
    bool isRightButtonDowned;
    bool isLeftButtonDowned;
    bool isDashButtonDowned;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        mushiTachi = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject mushi in mushiTachi)
        {
            mushi.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpswitch = true;
        horizontalKey = Input.GetAxis("Horizontal");
        if (!s_pushed && Input.GetKeyDown(KeyCode.S))
        {
            s_pushed = true;
            s_pushed_counter++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        int direction = 0;

        if (horizontalKey > 0 || isRightButtonDowned)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            direction = 1;
        }
        else if (horizontalKey < 0 || isLeftButtonDowned)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            direction = -1;
        }
               
        transform.Translate(direction * movespeed * Time.deltaTime, 0, 0);

        isGround = ground.IsGround();

        if (isGround)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || isDashButtonDowned )
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

        if (s_pushed)
        {
            if (s_pushed_counter <= 1) SearchMushiKun();
            
        }
    }

    private void Jump()
    {
        this.rb.AddForce(transform.up * jumpPower);
        jumpcount++;
    }

    private async void SearchMushiKun()
    {
        foreach (GameObject mushi in mushiTachi) mushi.SetActive(true);
        await Task.Delay(3000);
        foreach (GameObject mushi in mushiTachi) mushi.SetActive(false);
        s_pushed = false;
    }

    public void OnClickedJumpButton()
    {
        jumpswitch = true;
    }

    public void OnDownedDashButton()
    {
        isDashButtonDowned = true;
    }

    public void OnUppedDashButton()
    {
        isDashButtonDowned = false;
    }

    public void OnClickedSearchButton()
    {
        if (!s_pushed)
        {
            s_pushed = true;
            s_pushed_counter++;
        }
    }

    public void OnDownedRightButton()
    {
        isRightButtonDowned = true;
    }

    public void OnUppedRightButton()
    {
        isRightButtonDowned = false;
    }
    
    public void OnDownedLeftButton()
    {
        isLeftButtonDowned = true;
    }
    public void OnUppedLeftButton()
    {
        isLeftButtonDowned = false;
    }


}