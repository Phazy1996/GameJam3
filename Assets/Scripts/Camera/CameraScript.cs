﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float distance = 3.0f;
	[SerializeField]
	private float height = 3.0f;
	[SerializeField]
	private float damping = 5.0f;

	
	void Update () {
		Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		


		//transform.LookAt (target, target.up);
	}
}
