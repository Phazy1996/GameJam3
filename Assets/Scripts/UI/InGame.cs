using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour {

    [SerializeField]
    Text timeText;

    Timer timer;

    void Start() {
        timer = GetComponent<Timer>();
    }

    void Update() {
        timeText.text = timer.CurrentTimeString();
    }

}
