using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager Instance { get { Init(); return s_instance; } }
    // 유일한 매니저를 가지고 온다. 

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    void Start()
    {
        Init(); 
    }
    
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if(go==null)
            {
                go = new GameObject { name = "GameManager" };
                go.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<GameManager>();
        }
    }
}
