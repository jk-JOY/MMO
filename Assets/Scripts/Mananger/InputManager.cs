using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager
{
    //��������Ʈ-  
    //input�Ŵ����� ��ǥ�� üũ�ѵ� keyAction �̺�Ʈ��  /. ������ ����
    public Action keyAction = null;

    //������ �ҷ������
    void OnUpdate()
    {
        if (Input.anyKey == false)
        {
            return;
        }
        if(keyAction != null)
        {
            keyAction.Invoke();
        }
    }

}

