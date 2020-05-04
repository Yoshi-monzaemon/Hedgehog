using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushi_panel : MonoBehaviour
{
    public GameObject[] mushi_catch_number = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        mushi_catch_number[0].SetActive(false);
        mushi_catch_number[1].SetActive(false);
        mushi_catch_number[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameMaster.instance.mushi_counter)
        {
            case 1:
                mushi_catch_number[0].SetActive(true);
                break;
            case 2:
                mushi_catch_number[1].SetActive(true);
                break;
            case 3:
                mushi_catch_number[2].SetActive(true);
                break;
        }
    }
}
