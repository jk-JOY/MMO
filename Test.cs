using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1. 데이터(코드 = 클래스)를 만들어야한다. => 저장할 데이터 생성
/// 2. 그 데이터을 Json으로 변환. (택배상자로 포장)
/// Json이란 중간단계 클래스를 만들어서 해당 클래스를 Json으로 변환해서 저장. 
/// ----
/// 택배를 까서 
/// 원래의 제품을 받는 방법도 해야한다. 
/// </summary>
/// 

class Data
{ // 초깃값을 넣어줄 수 도 있음. 
    public string nickName;
    public int level;
    public int coin;
    public bool hasSkill;
    //저장하고 싶은 항목들을 저장한다.
}
public class Test : MonoBehaviour
{
    Data player = new Data() { nickName = "진기", level = 1, coin = 100, hasSkill = false }; //Data를 가지고 있는 새로운 player라는 객체를 만들어줬다. 

    private void Start()
    {
       string jsonData = JsonUtility.ToJson(player);
        Debug.Log(jsonData);


        //player에서 player2에게 정보를 다시 변환시킴.
        //다시 변환 되었다. 
        Data player2 = JsonUtility.FromJson<Data>(jsonData);
        print(player2.nickName);
        print(player2.level);
        print(player2.coin);
        print(player2.hasSkill);
    }

}
