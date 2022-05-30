using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //���ø��� ������ where T : obj
    //Resources.Load�� �Ȱ��� ���θ� �� ����
    /// <summary>
    //Ȥ�ö� ���ҽ��ε带 �ϰ� �ȴٸ� �� �Ŵ����� ���� ������ �ϰ� �Ǵϱ� �� �ɸ��� �ȴ�.
    /// </summary>0
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    //instantiate�� �������ٵ� path�־��� parent�־��� �� �־���.

    //������ �ٷ� ���� ������ ����ؼ�, prefabs���Ͽ� path�� �����ؼ� �����´�.
    // �Ŵ����� ���� Instantiate�� �Ҷ���  Prefabs/ �� �Ⱥ��̴� ���� ��Ģ���� �Ѵ�.
    
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
            //�ɼ����� prefab �� ������ parent�� �ٿ���ߵǴϱ�. 
           return Object.Instantiate(prefab, parent);
        }
    }


    //null �� �ƴ϶�� return else �� �ڱ⸦ �ı�
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
