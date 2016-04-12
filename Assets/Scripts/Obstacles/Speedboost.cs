using UnityEngine;
using System.Collections;

public class Speedboost : MonoBehaviour {


    // checking if player and the speedboost obj collide with each other, if true then change speed to higher value

    [SerializeField]
    PlayerMovement _player;

    void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            Debug.Log("SpeedBoost.");
            _player.MaxWalkSpeed = _player.MaxWalkSpeed * 2;
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Set Speed To Defaul Values");
        _player.MaxWalkSpeed = 5;
    }
}
