using UnityEngine;
using System.Collections;

public class Slowness : MonoBehaviour {

    /* het zoekt een object met een tag " Player " */

    PlayerMovement _player;



    // Use this for initialization
    void Start()
    {
        _player = GetComponent<PlayerMovement>();

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Slowness")
        {
            Debug.Log("Slowness");
            print(_player.MaxWalkSpeed);
            _player.MaxWalkSpeed = 2.5f;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        // set speed to default.
        _player.MaxWalkSpeed = 5;
    }
}
