using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefabs;

    GameObject tank;
    private void Start()
    {
        GameManager.Resource.Instantiate("Tank"); //�ٷ� ����...�Ѵ�.

        //GameManager.Resource.Destroy(tank);


        //prefabs = Resources.Load<GameObject>("Prefabs/cube");
        //tank = Instantiate(prefabs);

        Destroy(tank, 3f);
    }
}
