using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    // Public allows variable to be accessed within unity editorss
    public Transform hourArm;
    public Transform secondsArm;
    public Transform minuteArm;
    float degreesPerHr = 30f;
    float degreesPerTick = 6f;
    public bool constant;
    
    // Awake is called on initialization of object, similar to start but called first
    void Awake()
    {
        Debug.Log("Hey");    
    }

    // Start is called before the first frame update
    void Start()
    {
        DateTime time = DateTime.Now;
        hourArm.localRotation = Quaternion.Euler(0f, time.Hour*degreesPerHr, 0f);
        minuteArm.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerTick, 0f);
        secondsArm.localRotation = Quaternion.Euler(0f, time.Second * degreesPerHr, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (constant)
        {
            constantUpdate();
        }
        else
        {
            DateTime time = DateTime.Now;
            hourArm.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHr, 0f);
            minuteArm.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerTick, 0f);
            secondsArm.localRotation = Quaternion.Euler(0f, time.Second * degreesPerTick, 0f);
        }
    }

    private void constantUpdate()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourArm.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHr, 0f);
        minuteArm.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerTick, 0f);
        secondsArm.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerTick, 0f);
    }
}
