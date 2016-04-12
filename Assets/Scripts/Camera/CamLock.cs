using UnityEngine;
using System.Collections;

public class CamLock : MonoBehaviour {

	[SerializeField]
	private Transform player1;
	[SerializeField]
	private Transform player2;
	[SerializeField]
	private Transform player3;
	[SerializeField]
	private Transform player4;




	void Awake (){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player2.position.x > player1.position.x && player2.position.x > player3.position.x && player2.position.x > player4.position.x){
			transform.position = player2.position;
		}
		else if(player3.position.x > player1.position.x && player3.position.x > player2.position.x && player3.position.x > player4.position.x){
			transform.position = player3.position;
		}
		else if(player4.position.x > player1.position.x && player4.position.x > player2.position.x && player4.position.x > player3.position.x){
			transform.position = player4.position;
		}
		else transform.position = player1.position;

	
	}
}
