using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour {

    float movementSpeed =10;
    XInput _XInput;

	// Use this for initialization
	void Start ()
    {
        _XInput = GetComponent<XInput>();
	}
	
	// FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if(_XInput.LeftStickPos.x > 0.2)
        {
            transform.position = new Vector2(movementSpeed, 0f);
        }
        if(_XInput.LeftStickPos.x < -0.2)
        {
            
        }

    }
}
