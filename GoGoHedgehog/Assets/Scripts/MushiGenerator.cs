using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クラス名は大文字はじまりにする
// ローマ字はヘボン式
public class MushiGenerator : MonoBehaviour
{
    private string Player = "Player";
    public MushiPanel mushiPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player)
        {
            GameMaster.instance.mushiCounter++;
            this.gameObject.SetActive(false);
            mushiPanel.AddCaughtMushiImage(GameMaster.instance.mushiCounter);
        }
    }


}
