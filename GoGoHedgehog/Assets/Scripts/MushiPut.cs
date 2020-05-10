using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushiPut : MonoBehaviour
{
    public GameObject mushiObj;
    // Listで宣言してそれぞれUnity側でアタッチする
    public List<GameObject> mushiRespawnPointList;
    public GameObject indicator;
    public Transform canvas;
    public MushiPanel mushiPanel;
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        while (count-- > 0) 
         {
            int index = Random.Range(0, mushiRespawnPointList.Count);
            SpawnObj(mushiRespawnPointList[index].transform);

            GameObject prefab = (GameObject)Instantiate(indicator);
            prefab.transform.SetParent(canvas, false);

            TargetIndicator prefab_scripts = prefab.GetComponent<TargetIndicator>();
            prefab_scripts.target = mushiRespawnPointList[index].transform;

            mushiRespawnPointList.RemoveAt(index);
        }
    }

    void SpawnObj(Transform spawnpoint)
    {
        GameObject mushi = Instantiate(mushiObj, spawnpoint.position, transform.rotation);
        MushiGenerator mushiGenerator = mushi.GetComponent<MushiGenerator>();
        mushiGenerator.mushiPanel = mushiPanel;
    }
}
