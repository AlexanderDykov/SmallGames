using UnityEngine;
using System.Collections;

public class RocksMovement : MonoBehaviour {

    public Vector2 velocity = new Vector2(-4, 0);

    // Use this for initialization
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        StartCoroutine(Delete(6.0F));
    }

    IEnumerator Delete(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ObjectPool.Instance.Remove(this.gameObject);
    }
}
