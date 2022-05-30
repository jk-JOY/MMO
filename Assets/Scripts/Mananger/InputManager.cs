using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
     //델리게이트-  
    //input매니저가 대표로 체크한뒤 keyAction 이벤트로  /. 리스너 패턴
    public Action keyAction = null;

    //누군가 불러줘야해
    public void OnUpdate()  //체크하는 것 유일함. 
    {
        if (Input.anyKey == false)
        {
            return;
        }
        if (keyAction != null)
        {
            keyAction.Invoke();
        }
    }

}

