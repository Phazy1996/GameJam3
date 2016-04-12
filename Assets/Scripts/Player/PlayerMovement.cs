using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float speed;
    private float jumpForce;
    private bool isGrounded;
    private Vector2 xMove;
    private bool yMove;

    XInput xinput;


	// Use this for initialization
	void Start () {
        xinput = GetComponent<XInput>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    private void Movement () {
        xMove = (xinput.LeftStickPos);
        yMove = (xinput.AButtonDown);
    }
}
