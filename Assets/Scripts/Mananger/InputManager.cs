using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
     //��������Ʈ-  
    //input�Ŵ����� ��ǥ�� üũ�ѵ� keyAction �̺�Ʈ��  /. ������ ����
    public Action keyAction = null;

    //������ �ҷ������
    public void OnUpdate()  //üũ�ϴ� �� ������. 
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

