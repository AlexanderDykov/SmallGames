using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float JumpForce = 300f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
	    if (Input.GetButtonUp("Fire1"))
	    {
	        rb.velocity = Vector2.zero;
	        rb.AddForce(new Vector2(0, JumpForce));
	    }
	}

   
}
