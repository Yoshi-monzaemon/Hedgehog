using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundtag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if(isGroundExit)
        {
            isGround = false;
        }

        // フィールド変数取得のときに他のパラメータをいじるのはNoGood
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == groundtag)
        {
            isGroundEnter = true;
            Debug.Log("何かが判定に入りました");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundtag)
        {
            isGroundStay = true;
            Debug.Log("何かが判定に入り続けています");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundtag)
        {
            isGroundExit = true;
            Debug.Log("何かが判定を出ました");
        }
    }
}
