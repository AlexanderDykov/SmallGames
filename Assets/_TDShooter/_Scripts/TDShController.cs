using UnityEngine;
using System.Collections;

public class TDShController : MonoBehaviour
{

    public float speed;
    private float horizontal;
    private float vertical;
    private Rigidbody playerRigidbody;

    private Vector3 toward;
    private int floorMask;
    public float camRayLength;
    public Camera playerCamera;

	void Start ()
	{
        floorMask = LayerMask.GetMask("Floor");
	    playerRigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
        //Move
        horizontal = Input.GetAxis("Horizontal");
	    vertical = Input.GetAxis("Vertical");
        toward.Set(horizontal, 0f, vertical);
        playerRigidbody.MovePosition(transform.position + (toward.normalized * speed * Time.deltaTime));

        //Rotate
        Ray camRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            toward = floorHit.point - transform.position;
            toward.y = 0f;
            playerRigidbody.MoveRotation(Quaternion.LookRotation(toward));
        }
	}
}
