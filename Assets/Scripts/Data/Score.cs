using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    [SerializeField]
    int team1, team2 = 0;

    public void Scored(int team, int score = 1) {
        switch (team) {
            case 1:
                team1 += score;
                break;
            case 2:
                team2 += score;
                break;
            default:
                Debug.LogError("Team" + team + " does not exist!");
                break;
        }
    }

    public string Scoreboard() {
        return team1 + " - " + team2;
    }
}
