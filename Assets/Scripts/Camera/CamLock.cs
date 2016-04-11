using UnityEngine;
using System.Collections;

public class CamLock : MonoBehaviour {

	[SerializeField]
	private Transform player1;
	[SerializeField]
	private Transform player2;

	void Awake (){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player2.position.x > player1.position.x){
			transform.position = player2.position;
		}
		else transform.position = player1.position;

	
	}
}
