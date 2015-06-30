using System.Collections.Generic;
using UnityEngine;

interface IObjectPool<T>
{
    List<T> Create(T obj, int count);
    T Spawn(List<T> objects, Vector3 position, Quaternion rotation);
    void Remove(T obj);
}
