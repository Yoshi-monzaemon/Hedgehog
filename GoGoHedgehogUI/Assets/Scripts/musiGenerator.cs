using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musiGenerator : MonoBehaviour
{
    //public GameObject obj;
    //public float interval = 3.0f;
    private bool eatenCheck;
    private string Player = "Player";
    public bool mushi_catch = false;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // Update is called once per frame

    private void Update()
    {
        eatenCheck = this.mushiCheck();
        if (eatenCheck)
        {
            GameMaster.instance.mushi_counter++;
            this.gameObject.SetActive(false);
            Debug.Log(GameMaster.instance.mushi_counter);
        };
    }



    // Start is called before the first frame update
    private bool mushiCheck()
    {
        return mushi_catch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player)
        {
            Debug.Log("touched");
            mushi_catch = true;
            //this.gameObject.SetActive(false);
        }
    }


}
