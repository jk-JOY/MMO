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
    //피타고라스 정리를 하면 된다. 
    public float magnitude { get { return Mathf.Sqrt(x*x + y*y + z*z); } }




    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }
    //방향은 자기 자신에게 있는 모든 값들을 magnitude로 나눠주면 된다. 공식이야. 
    //방향은 같지만 실제로 사이즈를 계싼한다면 딱 1이 나오게 된다. 

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
        MyVector dir = to - from; // 방향을 b-a;    (5.0f, 0.0f, 0.0f)  dir = 목적지에서 나를뺀 것이 방향벡터

        dir = dir.normalized; // (1.0f,0.0f,0.0f);  정규화... 다 1로 바꿔버린다...
        //방향 벡터 
        //1. 거리(크기)는  magnitude를 사용
        //2. 실제 방향은 

        MyVector newPos = from + dir * _speed;
        //from이라는 점에서 원하는 방향(dir) 으로 _speed만큼을 움직인다. 
    }

    void Update()
    {
        //로컬에서 world에서 바꿔줌 TransformDirection
        //world에서에서 로컬로 바꿔줌 InverseTransformDirection

        //transform.position.magnitude;
        //transform.position.normalized;
    
        //자기가 바라보고 있는 그 로컬을 기준으로 연산하는. 
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

