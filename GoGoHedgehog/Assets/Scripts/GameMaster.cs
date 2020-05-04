using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public bool goal;
    public static GameMaster instance = null;
    public int mushi_counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        goal = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
