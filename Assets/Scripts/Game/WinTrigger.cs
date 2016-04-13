using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        string team = other.transform.parent.name;

        team.ToLower();

        if (team == "team1") {
            // win
        } else if (team == "team2") {
            // more win
        }
    }
}
