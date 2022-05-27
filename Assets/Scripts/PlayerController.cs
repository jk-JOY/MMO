using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �뵵
//1.��ġ ���͸� ������ �� �ִ�. 

//2. ���� ���� forward���� ģ������ ������ ��Ÿ���� ģ���� 
struct MyVector
{
/// <summary>
/// normalized  
/// 
///���ʹ� f �� 3���� ��� �ִ� ����ü 
///2��
///��ġ
///����  
///
///��ġ�� ��ǥ�� �־ ���ϰ� �������� ���������, 
///�� ���� ���̿� ������ �̿��ؼ� ���⺤�͸� ���س� �� �ִµ� 
///
///���⺤�ʹ� (�Ÿ�(ũ��)),(���� ����) �ΰ��� ��� �ִµ�
/// ���� magnitude�� normailedz �� ����ߴµ�
/// �Ÿ� 000ũ�Ⱑ 1�� ���⺤�͸� ���� �� �ְ� 
/// �븻������ �� ����ϸ� ����Ű�� ������ �Q������ , 
/// speed ���� ���� ���ϸ� ���� �������� �̵��ϴ� �͵� �� �� �ִ�
/// </summary>



    public float x;
    public float y;
    public float z;

    
    //��Ÿ��󽺸� ����ؼ� ũ�⸦ �˾Ƴ� �� �ִ�.
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }


//������ ������, ������ �� �� 1�� ���Ͱ� ���´�. 
    public MyVector normalized {  get { return new MyVector(x/ magnitude, y/ magnitude, z/magnitude); } }


    //������ 
    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    //�� ���͸� �������� 
    public static MyVector operator +(MyVector a, MyVector b) // (a,b)�κ��͸� �������� � �ൿ�� �Ͼ�°�?
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);  // �κ��� ������ ������ �����Ѱ�. 
    }

    public static MyVector operator -(MyVector a, MyVector b) // (a,b)�κ��͸� �������� � �ൿ�� �Ͼ�°�?
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);  // �κ��� ������ ������ �����Ѱ�. 
    }

    public static MyVector operator *(Vector3 a, float d)
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

        MyVector dir = to - from; // (5.0f, 0.0f, 0.0f);)

        //���� ���� - 1. �Ÿ��� ũ���� �˼� �ְ�  -> magnitude.
        //            2., ���������� �� �� ����. 


        dir = dir.normalized; //1,0,0  5�� 1�� ���⺤�ͷ� ���Ѵ�.
                              //
        MyVector newPos = from + dir * _speed;


        //���� = to - from     
        //���������� ���� ���°�. 
        //magnitue.  ������ ũ�⸦ ��ȯ�Ѵ�.
        //nomarilize  ������ 

    }

    void Update()
    {
        //���ÿ��� world���� �ٲ��� TransformDirection
        //world�������� ���÷� �ٲ��� InverseTransformDirection

        //��� ���������̴�. ũ�Ⱑ 1¥���� ���� == �������� 
        //���⿡ ���� ������ �����س���. forward ���� ģ����

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

