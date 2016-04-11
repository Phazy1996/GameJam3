using UnityEngine;
using System.Collections;

public class ControllerTest : MonoBehaviour {

    XInput xinput;

	void Start () {
        xinput = GetComponent<XInput>();
	}
	
	// Update is called once per frame
	void Update () {
        print(xinput.LeftStickPos);
	}
}
