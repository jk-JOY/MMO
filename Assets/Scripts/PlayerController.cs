using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//벡터의 용도
//1.위치 벡터를 조정할 수 있다. 

//2. 방향 벡터 forward같은 친구들이 방향을 나타내는 친구들 
struct MyVector
{
/// <summary>
/// normalized  
/// 
///벡터는 f 를 3개를 들고 있는 구조체 
///2개
///위치
///방향  
///
///위치는 좌표를 넣어서 더하고 뺄샘으로 사용하지만, 
///두 지점 사이에 뺄샘을 이용해서 방향벡터를 구해낼 수 있는데 
///
///방향벡터는 (거리(크기)),(실제 방향) 두개를 담고 있는데
/// 각각 magnitude와 normailedz 를 사용했는데
/// 거리 000크기가 1인 방향벡터를 꺼낼 수 있고 
/// 노말라이즈 를 사용하면 가리키는 방향은 똒깥지만 , 
/// speed 같은 것을 곱하면 그쪽 방향으로 이동하는 것도 할 수 있다
/// </summary>



    public float x;
    public float y;
    public float z;

    
    //피타고라스를 사용해서 크기를 알아낼 수 있다.
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }


//방향은 같지만, 사이즈 가 딱 1인 벡터가 나온다. 
    public MyVector normalized {  get { return new MyVector(x/ magnitude, y/ magnitude, z/magnitude); } }


    //생성자 
    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    //두 벡터를 더했을때 
    public static MyVector operator +(MyVector a, MyVector b) // (a,b)두벡터를 더했을때 어떤 행동이 일어나는가?
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);  // 두벡터 사이의 덧셈을 정리한것. 
    }

    public static MyVector operator -(MyVector a, MyVector b) // (a,b)두벡터를 더했을때 어떤 행동이 일어나는가?
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);  // 두벡터 사이의 덧셈을 정리한것. 
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

        //방향 벡터 - 1. 거리의 크리를 알수 있고  -> magnitude.
        //            2., 실제방향을 알 수 있음. 


        dir = dir.normalized; //1,0,0  5가 1로 방향벡터로 변한다.
                              //
        MyVector newPos = from + dir * _speed;


        //방향 = to - from     
        //목적지에서 나를 뺴는것. 
        //magnitue.  벡터의 크기를 반환한다.
        //nomarilize  벡터의 

    }

    void Update()
    {
        //로컬에서 world에서 바꿔줌 TransformDirection
        //world에서에서 로컬로 바꿔줌 InverseTransformDirection

        //모두 단위벡터이다. 크기가 1짜리인 벡터 == 단위벡터 
        //방향에 대한 정보만 추출해낸다. forward 같은 친구들

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

