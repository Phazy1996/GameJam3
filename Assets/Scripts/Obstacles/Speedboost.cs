using UnityEngine;
using System.Collections;

public class Speedboost : MonoBehaviour {


    // checking if player and the speedboost obj collide with each other, if true then change speed to higher value

   // [SerializeField]
    PlayerMovement _player;


    void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SpeedBoost")
        {
            Debug.Log("SpeedBoost");
            print(_player.MaxWalkSpeed);
            _player.MaxWalkSpeed = 10f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Set Speed To Defaul Values");
        _player.MaxWalkSpeed = 5;
    }
}
