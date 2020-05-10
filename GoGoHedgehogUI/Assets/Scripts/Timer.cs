using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameMaster.instance.mushi_counter < 3)

        if (GameMaster.instance.mushiCounter < 3)
        {
            time += Time.deltaTime;
            // ここは虫を3匹以上捕まえた時点でタイマーが止まるならUIへの表示処理も必要ない。
            int t = Mathf.FloorToInt(time);

            // Update内にGetComponentは書いてはダメ。
            // GetComponentは重い処理なので毎フレーム呼ぶとあっという間にアプリがガクつく
            // 代わりにuiTextをフィールド変数で宣言して、unity側でアタッチするか
            // Start()で1回だけ取得する
            uiText.text = "Time:" + t;
        }
    }
}
