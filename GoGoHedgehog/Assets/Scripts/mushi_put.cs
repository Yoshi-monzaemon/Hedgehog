using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushi_put : MonoBehaviour
{
    public GameObject mushiObj;

    public GameObject mushi_respawn_point_1;
    public GameObject mushi_respawn_point_2;
    public GameObject mushi_respawn_point_3;
    public GameObject mushi_respawn_point_4;
    public GameObject mushi_respawn_point_5;

    int point_number_min = 1;
    int point_number_max = 5;
    int count = 3;
    List<int> numbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = point_number_min; i <= point_number_max; i++)
        {
            numbers.Add(i);
        }
        
        while (count-- > 0)
        {
            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];

            switch (ransu)
            {
                case 1:
                    SpawnObj(mushi_respawn_point_1.transform);
                    break;
                case 2:
                    SpawnObj(mushi_respawn_point_2.transform);
                    break;
                case 3:
                    SpawnObj(mushi_respawn_point_3.transform);
                    break;
                case 4:
                    SpawnObj(mushi_respawn_point_4.transform);
                    break;
                case 5:
                    SpawnObj(mushi_respawn_point_5.transform);
                    break;
            }


            numbers.RemoveAt(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObj(Transform spawnpoint)
    {
        Instantiate(mushiObj, spawnpoint.position, transform.rotation);
    }
}
