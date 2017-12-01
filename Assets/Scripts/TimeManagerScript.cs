using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour {

    public float timeTotalMin; //time in minutes of 1 day
    public float speed; //speed up in time per day, determined by timeTotal

    public float initTimeHr; //Initial starting time in hours (0 to 23)

    public static float timeOfDay; //public accessible float storing exact time of the day in seconds
    public static int day; //public accessible day count

    public float hour; //To show hour in inspector

	// Use this for initialization
	void Start () {
        speed = 86400 / (timeTotalMin * 60);
        timeOfDay = initTimeHr * 60 * 60;
        day = 0;
        hour = initTimeHr;
	}
	
	// Update is called once per frame
	void Update () {

        // Update time of day according to speed
        timeOfDay += Time.deltaTime * speed;

        //Update hour
        hour = timeOfDay / 3600;

        //Day update
        if (timeOfDay - (initTimeHr * 60 * 60) >= 84600)
        {
            day++;
        }

        //reset time of day at 12 am
        if (timeOfDay >= 84600)
        {
            timeOfDay = 0;
        }

	}
}
