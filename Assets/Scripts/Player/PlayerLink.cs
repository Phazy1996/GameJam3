using UnityEngine;
using System.Collections;

public class PlayerLink : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private DistanceJoint2D dis2D;
    private float distance;

    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;
    [SerializeField]
    private Transform player3;
    [SerializeField]
    private Transform player4;

    [SerializeField]
    private GameObject [] team1;
    [SerializeField]
    private GameObject [] team2;

	// Use this for initialization
	void Start () {
       // team1[2];
      //  team2[2];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        dis2D.distance = 3f;
       // dis2D.distance = dis2D.maxDistanceOnly;
	}
}
