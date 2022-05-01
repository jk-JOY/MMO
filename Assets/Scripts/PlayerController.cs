using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1.위치 벡터
//2. 방향 벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;

    public float magnitude { get { return 0; } }



    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    public static MyVector operator +(MyVector a, MyVector b) // (a,b)두벡터를 더했을때 어떤 행동이 일어나는가?
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);  // 두벡터 사이의 덧셈을 정리한것. 
    }

    public static MyVector operator -(MyVector a, MyVector b) // (a,b)두벡터를 더했을때 어떤 행동이 일어나는가?
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);  // 두벡터 사이의 덧셈을 정리한것. 
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
    
        //방향 벡터 - 1. 거리의 크리를 알수 있고, 실제방향을 알 수 있음. 
    }

    void Update()
    {
        //로컬에서 world에서 바꿔줌 TransformDirection
        //world에서에서 로컬로 바꿔줌 InverseTransformDirection

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

