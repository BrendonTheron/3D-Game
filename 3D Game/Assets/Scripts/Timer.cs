using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormat format;
    private Dictionary<TimerFormat, string> timeFormates = new Dictionary<TimerFormat, string>();


    // Start is called before the first frame update
    void Start()
    {
        timeFormates.Add(TimerFormat.Whole, "0");
        timeFormates.Add(TimerFormat.TenthDecimal, "0.0");
        timeFormates.Add(TimerFormat.HundrethDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormates[format]) : currentTime.ToString();
    }

    public enum TimerFormat
    {
        Whole,
        TenthDecimal,
        HundrethDecimal
    }
}
