using UnityEngine;
using System.Collections;

public class Slowness : MonoBehaviour {

    /* het zoekt een object met een tag " Player " */

    [SerializeField]
    PlayerMovement _player;

    // Use this for initialization
    void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            // set speed to a slower value.
            _player.MaxWalkSpeed = _player.MaxWalkSpeed * 0.5f;
            

        }
    }
    void OnCollisionExit(Collision col)
    {
        // set speed to default.
        _player.MaxWalkSpeed = 5;
    }
}
