using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeCycle : MonoBehaviour
{
    [SerializeField] Light sun;
    [SerializeField, Range(0,24)] float time;

    [SerializeField] private TextMeshProUGUI timeText;

    public Gradient lightColor;
    public Gradient ambientColor;
    public Gradient fogColor;

    public bool twelveHourFormat;

    void Start()
    {
        sun = GetComponent<Light>();
    }

    void Update()
    {
        if(Application.isPlaying)
        {
            time += Time.deltaTime/60;
            time %= 24;
            UpdateTime((time / 24f));

            DateTime dateTime = DateTime.Today.Add(TimeSpan.FromHours(time));
            if (twelveHourFormat) timeText.text = dateTime.ToString("hh:mm tt");
            else timeText.text = dateTime.ToString("HH:mm");
        }
    }

    private void UpdateTime(float percent)
    {
        RenderSettings.ambientLight = ambientColor.Evaluate(percent);
        RenderSettings.fogColor = fogColor.Evaluate(percent);
        sun.color = lightColor.Evaluate(percent);
        sun.transform.localRotation = Quaternion.Euler(new Vector3((percent * 360f) - 90f, -170, 0));
    }
}
