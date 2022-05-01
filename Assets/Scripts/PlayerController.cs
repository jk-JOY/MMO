using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1.��ġ ����
//2. ���� ����
struct MyVector
{
    public float x;
    public float y;
    public float z;

    public float magnitude { get { return 0; } }



    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    public static MyVector operator +(MyVector a, MyVector b) // (a,b)�κ��͸� �������� � �ൿ�� �Ͼ�°�?
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);  // �κ��� ������ ������ �����Ѱ�. 
    }

    public static MyVector operator -(MyVector a, MyVector b) // (a,b)�κ��͸� �������� � �ൿ�� �Ͼ�°�?
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);  // �κ��� ������ ������ �����Ѱ�. 
    }
}


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    public GameObject _obj;


    void Start()
    {
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);

        MyVector dir = to - from; // (-5.0f)
    
        //���� ���� - 1. �Ÿ��� ũ���� �˼� �ְ�, ���������� �� �� ����. 
    }

    void Update()
    {
        //���ÿ��� world���� �ٲ��� TransformDirection
        //world�������� ���÷� �ٲ��� InverseTransformDirection

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
    }
}

