using UnityEngine;
using System.Collections;

public class ZigZagController : MonoBehaviour {

    public float speed = 5f;
    Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            direction = (direction == Vector3.forward) ? Vector3.left : Vector3.forward;
            
        }
        float temp = speed * Time.deltaTime;
        transform.Translate(direction * temp);
	}
}
