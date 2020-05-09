using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushiPut : MonoBehaviour
{
    public GameObject mushiObj;
    // Listで宣言してそれぞれUnity側でアタッチする
    public List<GameObject> mushiRespawnPointList;
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        while (count-- > 0) 
         {
            int index = Random.Range(0, mushiRespawnPointList.Count);
            SpawnObj(mushiRespawnPointList[index].transform);
            numbers.RemoveAt(index);
        }
    }

    void SpawnObj(Transform spawnpoint)
    {
        Instantiate(mushiObj, spawnpoint.position, transform.rotation);
    }
}
