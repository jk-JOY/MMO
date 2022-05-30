using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //템플릿을 조건을 where T : obj
    //Resources.Load를 똑같이 래핑만 한 상태
    /// <summary>
    //혹시라도 리소스로드를 하게 된다면 이 매니저를 통해 접근을 하게 되니까 딱 걸리게 된다.
    /// </summary>0
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    //instantiate를 랩핑할텐데 path있었고 parent넣어줄 수 있었다.

    //랩핑한 바로 위의 버전을 사용해서, prefabs산하에 path에 접근해서 가져온다.
    // 매니저를 통한 Instantiate를 할때는  Prefabs/ 를 안붙이는 것을 규칙으로 한다.
    
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefab/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load Prefabs : {path}");
            return null;
        }
        else
        {
            //옵션으로 prefab 을 생성해 parent에 붙여줘야되니까. 
           return Object.Instantiate(prefab, parent);
        }
    }


    //null 이 아니라면 return else 는 자기를 파괴
    public void Destroy(GameObject go)
    {
        if(go != null)
        {
            return;
        }
        else
        {
            Object.Destroy(go);
        }
    }
}
