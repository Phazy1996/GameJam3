using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

    [SerializeField, ]
    int hours, minutes, seconds = 0;

    [SerializeField]
    bool running = false;

    public int Hours {
        get { return hours; }
    }

    public int Minutes {
        get { return minutes; }
    }

    public int Seconds {
        get { return seconds; }
    }

    private List<List<int>> savedTimes = new List<List<int>>();

    void FixedUpdate() {
        if (running) {
            StartCoroutine(TickTock());
            if (seconds >= 60) {
                seconds = 0;
                minutes++;
            }
            if (minutes >= 60) {
                minutes = 0;
                hours++;
            }
        }
    }

    IEnumerator TickTock() {
        yield return new WaitForSeconds(1);
        seconds++;
    }

    public void Start() {
        running = true;
    }

    public void Pause() {
        running = false;
    }

    public void Stop() {
        running = false;
        hours = minutes = seconds = 0;
    }

    public void Toggle() {
        if (!running)
            running = true;
        else
            running = false;
    }

    public void Save() {
        List<int> time = new List<int>();

        time[0] = hours; time[1] = minutes; time[2] = seconds;

        savedTimes.Add(time);
    }
}
