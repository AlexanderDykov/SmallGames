using UnityEngine;
using System.Collections;

public class BlockBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gem;

    void OnEnable()
    {
        int rnd = Random.Range(0, 5);
        gem.SetActive(rnd == 0);
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rb.isKinematic = false;
            StartCoroutine("Destroy", 2f);
        }
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        rb.isKinematic = true;
        ObjectPool.Instance.Remove(this.gameObject);
        BlockGenerator.Instance.Spawn();
        
    }
}
