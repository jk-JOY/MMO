using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;

    public Vector3 dir = new Vector3(0, 15, -10);

    private void Update()
    {
        //������Բ�?
        this.gameObject.transform.position = Player.transform.position + dir;
    }
}
