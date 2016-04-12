using UnityEngine;
using System.Collections;

public class ControllerTest : MonoBehaviour {

    XInput xinput;

	void Start () {
        xinput = GetComponent<XInput>();
	}

	void Update () {
        print(xinput.LeftStickPos);
        print(xinput.AButtonDown);
	}
}
