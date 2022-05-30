using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefabs;

    GameObject tank;
    private void Start()
    {
        GameManager.Resource.Instantiate("Tank"); //바로 생성...한다.

        //GameManager.Resource.Destroy(tank);


        //prefabs = Resources.Load<GameObject>("Prefabs/cube");
        //tank = Instantiate(prefabs);

        Destroy(tank, 3f);
    }
}
