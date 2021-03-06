﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPathScript : MonoBehaviour {
    
    public float startY; //where the sun starts from
    public float endY; //where the sun should reset it's position in terms of y and stop cycle
    public float riseTimeHr; //time when sun rises in hours (0 - 23)
    public float horizon; //to avoid reflections

    //For calculating intermediate position
    public static float y;
    public static float x;
    private float frac;

    //For reset
    private bool startCycle;
    private float riseTimeSec;

	// Use this for initialization
	void Start () {
        riseTimeSec = riseTimeHr * 60 * 60;

        //Getting value of y accroding to time of day
        if (TimeManagerScript.timeOfDay >= riseTimeSec && TimeManagerScript.timeOfDay <= 43200)
        {
            startCycle = true;
            frac = (TimeManagerScript.timeOfDay - riseTimeSec) / (43200 - riseTimeSec);
            y = Mathf.Lerp(startY, endY, frac);
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
        } else
        {
            startCycle = false;
            y = startY;
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
        }

        //to avoid reflections below horizon
        if (GetComponent<Transform>().position.y >= horizon - 1f)
        {
            GetComponent<MeshRenderer>().enabled = true;
        } else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (TimeManagerScript.timeOfDay >= riseTimeSec && TimeManagerScript.timeOfDay <= 43200)
        {
            //sun should be visible
            startCycle = true;
        }
        else
        {
            //sun not visible
            startCycle = false;
        }

        if (startCycle)
        {

            //Calculating value of y according to the time
            frac = (TimeManagerScript.timeOfDay - riseTimeSec) / (43200 - riseTimeSec);
            y = Mathf.Lerp(startY, endY, frac);

            //Value of x calculated using the curve (x + 12)^2 + (y + 5)^2 = 18.5^2
            x = Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f;

            //sun position set according to the x and y values
            GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

        } else
        {

            //Resetting position
            y = startY;
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);

        }

        //to avoid reflections below horizon
        if (GetComponent<Transform>().position.y >= horizon - 1f)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
