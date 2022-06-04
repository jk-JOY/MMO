using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1. ������ ��ü �־���Ѵ�. (Ű�׸�ƽ�� off)
    // 1. ������ �ݶ��̴��� �־���Ѵ�. isTrigeer off
    //3. ��뿡�� collider �־���Ѵ�. isTrigger off
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($" Trigger @ {other.gameObject.name}!");
    }

    //�� �� �ݶ��̴��� �־���ϳ�.
    // �� �� �ϳ��� ��Ʈ���� �Ǿ��־���ϳ�.
    // �� �� �ϳ��� ��ü�� �־���Ѵ�. 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" Trigger @ {other.gameObject.name}!");
    }

    private void Update()
    {

        //���� ����
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
