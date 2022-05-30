using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager s_instance; // ���ϼ��� ����ȴ�.
    private static GameManager Instance { get { Init(); return s_instance; } }
    // ������ �Ŵ����� ������ �´�. 

    // static GameManager GetInstance() { return Instance; }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    void Start()
    {
        Init();
    }


    private void Update()
    {
        _input.OnUpdate(); //�Է���ġ�� ����
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if (go == null)
            {
                go = new GameObject { name = "GameManager" };
                go.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<GameManager>();
        }
    }
}
