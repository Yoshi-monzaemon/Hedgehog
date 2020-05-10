using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushiPanel : MonoBehaviour
{
    public GameObject[] caughtImageList = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        caughtImageList[0].SetActive(false);
        caughtImageList[1].SetActive(false);
        caughtImageList[2].SetActive(false);
    }

    // 毎フレームでSetActiveを呼ぶのは非効率
    // mushiCounterが増えたタイミングでAddCatchedMushiImage()みたいなメソッドを呼べばいい
    public void AddCaughtMushiImage(int count) 
    {
        int index = count - 1;
        caughtImageList[index].SetActive(true);
    }
}
