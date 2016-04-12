using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public LevelManager Manager;
	Camera camera;

	void Start() {
		camera = GetComponent<Camera>();
	}

	void Update() {
		Vector3 viewPos1 = camera.WorldToViewportPoint(target1.position);

		Vector3 viewPos2 = camera.WorldToViewportPoint(target2.position);

		Vector3 viewPos3 = camera.WorldToViewportPoint(target3.position);

		Vector3 viewPos4 = camera.WorldToViewportPoint(target4.position);

		if (viewPos1.x < 0.0F || viewPos2.x < 0.0F){
			Debug.Log("player 1 or 2  is out of cam");
			Dead();
		}

		else if (viewPos3.x < 0.0F || viewPos4.x < 0.0F){
			Debug.Log("player 3 or 4 is out of cam");
			Dead();
		}
	}

	private void Dead() {
		Manager.EndScreen();

	}
}
