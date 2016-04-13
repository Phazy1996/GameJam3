using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {

    [Header("Ready for some super dirty super cheap code?")]
    [SerializeField]
    Animator winAnim;
    [SerializeField]
    Animator timerText;
    Text winText;
    [SerializeField]
    Timer timer;
    bool ended = false;

    [Header("Those get me quick access."),Tooltip("Ignore this variable. I just wanted another header."), SerializeField]
    int zero = 0;

    void Start() {
        winText = winAnim.gameObject.GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!ended) {
            string team = other.transform.parent.name;

            team = team.ToLower();

            if (team == "team1") {
                EndGame();
                winText.text = "Team 1 wins!";
            } else if (team == "team2") {
                EndGame();
                winText.text = "Team 2 wins!";
            }
        }
    }

    void EndGame() {
        ended = true;
        winAnim.SetTrigger("EndGame");
        timerText.SetTrigger("EndGame");
        timer.Pause();
    }
}
