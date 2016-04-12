using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour {

    [SerializeField]
    Text scoreText, timeText;

    Score score;
    Timer timer;

    void Start() {
        score = GetComponent<Score>();
        timer = GetComponent<Timer>();
    }

    void Update() {
        scoreText.text = score.Scoreboard();
        timeText.text = timer.CurrentTimeString();
    }

}
