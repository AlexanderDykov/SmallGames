using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour, IObjectPool<GameObject>
{
    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ObjectPool>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
    #region IObjectPool implementation
    public List<GameObject> Create(GameObject obj, int count)
    {
        List<GameObject> lst = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject newObj = Instantiate(obj) as GameObject;
            newObj.SetActive(false);
            lst.Add(newObj);
        }
        return lst;
    }

    public GameObject Spawn(List<GameObject> objects, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                objects[i].transform.position = position;
                objects[i].transform.rotation = rotation;
                objects[i].SetActive(true);
                return objects[i];
            }
        }
        return null;
    }

    public void Remove(GameObject obj)
    {
        obj.SetActive(false);
    }
    #endregion
}