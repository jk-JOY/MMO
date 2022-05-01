using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1. ������(�ڵ� = Ŭ����)�� �������Ѵ�. => ������ ������ ����
/// 2. �� �������� Json���� ��ȯ. (�ù���ڷ� ����)
/// Json�̶� �߰��ܰ� Ŭ������ ���� �ش� Ŭ������ Json���� ��ȯ�ؼ� ����. 
/// ----
/// �ù踦 � 
/// ������ ��ǰ�� �޴� ����� �ؾ��Ѵ�. 
/// </summary>
/// 

class Data
{ // �ʱ갪�� �־��� �� �� ����. 
    public string nickName;
    public int level;
    public int coin;
    public bool hasSkill;
    //�����ϰ� ���� �׸���� �����Ѵ�.
}
public class Test : MonoBehaviour
{
    Data player = new Data() { nickName = "����", level = 1, coin = 100, hasSkill = false }; //Data�� ������ �ִ� ���ο� player��� ��ü�� ��������. 

    private void Start()
    {
       string jsonData = JsonUtility.ToJson(player);
        Debug.Log(jsonData);


        //player���� player2���� ������ �ٽ� ��ȯ��Ŵ.
        //�ٽ� ��ȯ �Ǿ���. 
        Data player2 = JsonUtility.FromJson<Data>(jsonData);
        print(player2.nickName);
        print(player2.level);
        print(player2.coin);
        print(player2.hasSkill);
    }

}
