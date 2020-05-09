using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クラス名は大文字はじまりにする
// ローマ字はヘボン式
public class MushiGenerator : MonoBehaviour
{
    private bool eatenCheck;
    private string Player = "Player";
    public bool mushi_catch = false;
    public MushiPanel mushiPanel;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // Update is called once per frame

    private void Update()
    {
        eatenCheck = mushiCheck();
        if (eatenCheck)
        {
            GameMaster.instance.mushiCounter++;
            mushiPanel.AddCatchedMushiImage(GameMaster.instance.mushiCounter);
            this.gameObject.SetActive(false);
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
            mushi_catch = true;
        }
    }


}
