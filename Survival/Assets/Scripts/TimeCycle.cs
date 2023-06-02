using UnityEngine;
using TMPro;
using System;

public class TimeCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField, Range(0,24)] private float time;
    public Gradient lightColor;
    public Gradient ambientColor;
    public Gradient fogColor;

    [SerializeField] TextMeshProUGUI timeText;
    public bool twelveHourFormat;

    //void Start() => sun = GetComponent<Light>();

    private void OnValidate() => SetTime();

    void Update() => SetTime();

    private void SetTime()
    {
        Shader.SetGlobalVector("_SunDirection", transform.forward);
        Shader.SetGlobalVector("_MoonDirection", -transform.forward);
        time += Time.deltaTime / 60;
        time %= 24;
        UpdateTime((time / 24f));

        DateTime dateTime = DateTime.Today.Add(TimeSpan.FromHours(time));
        if (twelveHourFormat) timeText.text = dateTime.ToString("hh:mm tt");
        else timeText.text = dateTime.ToString("HH:mm");
    }

    private void UpdateTime(float percent)
    {
        RenderSettings.ambientLight = ambientColor.Evaluate(percent);
        RenderSettings.fogColor = fogColor.Evaluate(percent);
        sun.color = lightColor.Evaluate(percent);
        sun.transform.localRotation = Quaternion.Euler(new Vector3((percent * 360f) - 90f, -170, 0));
    }
}
