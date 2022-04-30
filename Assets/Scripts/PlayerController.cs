using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MyVector
{
    public float x;
    public float y;
    public float z;

    //           +
    //      +    +
    //+----------+
    //��Ÿ���� ������ �ϸ� �ȴ�. 
    public float magnitude { get { return Mathf.Sqrt(x*x + y*y + z*z); } }




    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }
    //������ �ڱ� �ڽſ��� �ִ� ��� ������ magnitude�� �����ָ� �ȴ�. �����̾�. 
    //������ ������ ������ ����� ����Ѵٸ� �� 1�� ������ �ȴ�. 

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
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
        MyVector dir = to - from; // ������ b-a;    (5.0f, 0.0f, 0.0f)  dir = ���������� ������ ���� ���⺤��

        dir = dir.normalized; // (1.0f,0.0f,0.0f);  ����ȭ... �� 1�� �ٲ������...
        //���� ���� 
        //1. �Ÿ�(ũ��)��  magnitude�� ���
        //2. ���� ������ 

        MyVector newPos = from + dir * _speed;
        //from�̶�� ������ ���ϴ� ����(dir) ���� _speed��ŭ�� �����δ�. 
    }

    void Update()
    {
        //���ÿ��� world���� �ٲ��� TransformDirection
        //world�������� ���÷� �ٲ��� InverseTransformDirection

        //transform.position.magnitude;
        //transform.position.normalized;
    
        //�ڱⰡ �ٶ󺸰� �ִ� �� ������ �������� �����ϴ�. 
        //translate
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
