using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1. 나한테 강체 있어야한다. (키네마틱은 off)
    // 1. 나한테 콜라이더가 있어야한다. isTrigeer off
    //3. 상대에게 collider 있어야한다. isTrigger off
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($" Trigger @ {other.gameObject.name}!");
    }

    //둘 다 콜라이더가 있어야하낟.
    // 둘 중 하나는 온트리거 되어있어야하낟.
    // 둘 중 하나는 강체가 있어야한다. 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" Trigger @ {other.gameObject.name}!");
    }

    private void Update()
    {

        //나의 방향
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawLine(transform.position + Vector3.up, look * 100, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Raycast!{hit.collider.gameObject.name}");

        }
    }
}
