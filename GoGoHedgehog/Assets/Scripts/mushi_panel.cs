using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushiPanel : MonoBehaviour
{
    public GameObject[] mushi_catch_number = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        mushi_catch_number[0].SetActive(false);
        mushi_catch_number[1].SetActive(false);
        mushi_catch_number[2].SetActive(false);
    }

    // 毎フレームでSetActiveを呼ぶのは非効率
    // mushiCounterが増えたタイミングでAddCatchedMushiImage()みたいなメソッドを呼べばいい
    public void AddCatchedMushiImage(int count) 
    {
        int index = count - 1;
        mushi_catch_number[index].SetActive(false);
    }
}
