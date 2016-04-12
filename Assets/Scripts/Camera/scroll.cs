using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	[SerializeField]
	private float scrollSpeed = 100f;
	private float parralax = 2f;

	void Update () {
	    
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x += Time.deltaTime / scrollSpeed;

		mat.mainTextureOffset = offset;

	}
}
