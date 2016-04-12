using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

    [SerializeField]
    int hours, minutes, seconds, milleseconds = 0;

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
            if (milleseconds >= 100) {
                milleseconds = 0;
                seconds++;
            }
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
        yield return new WaitForSeconds(0.1f);
        milleseconds++;
    }

    public void Start() {
        running = true;

        print(CurrentTimeString());
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

    public List<int> CurrentTimeList() {
        return new List<int>(){hours, minutes, seconds};
    }

    public string CurrentTimeString() {
        string Hours, Minutes, Seconds;

        string time = "00:00:00";

        Hours = hours.ToString("D" + 2.ToString());
        Minutes = minutes.ToString("D" + 2.ToString());
        Seconds = seconds.ToString("D" + 2.ToString());

        time = Hours + ":" + Minutes + ":" + Seconds;

        return time;
    }
}
