using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPathScript : MonoBehaviour
{

    public float startY; //where the moon starts from
    public float endY; //where the moon should reset it's position in terms of y and stop cycle
    public float riseTimeHr; //time when moon rises in hours (0 - 23)
    public float horizon; //to avoid reflections
    public GameObject sun;
    private float timeOfDay;

    //For calculating intermediate position
    public static float y;
    public static float x;
    private float frac;
    private float fracFlare;

    //For reset
    private float riseTimeSec;

    // Use this for initialization
    void Start()
    {

        riseTimeSec = riseTimeHr * 60 * 60;

        //Getting value of y accroding to time of day
        if (TimeManagerScript.timeOfDay >= riseTimeSec && TimeManagerScript.timeOfDay < 86400)
        {
            frac = (TimeManagerScript.timeOfDay - riseTimeSec) / (86400 - riseTimeSec);
            y = Mathf.Lerp(startY, endY, frac);
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
        }
        else
        { 
            y = startY;
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
        }

        //to avoid reflections below horizon
        if (GetComponent<Transform>().position.y >= horizon - 1f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Transform>().position.y <= GetComponent<MoonPathScript>().horizon - 1f)
        {

            fracFlare = (GetComponent<MoonPathScript>().horizon - 1f - GetComponent<Transform>().position.y) / (GetComponent<MoonPathScript>().horizon - 1f - GetComponent<MoonPathScript>().startY);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                Mathf.Clamp(1 - fracFlare, 0, 0.25f)
            );

        } else
        {

            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                0.25f
            );

        }

        if (TimeManagerScript.timeOfDay >= riseTimeSec && TimeManagerScript.timeOfDay <= 82800)
        {

            //Calculating value of y according to the time
            frac = (TimeManagerScript.timeOfDay - riseTimeSec) / (82800 - riseTimeSec);
            y = Mathf.Lerp(startY, endY, frac);

            //Value of x calculated using the curve (x + 12)^2 + (y + 5)^2 = 18.5^2
            x = Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f;

            //moon position set according to the x and y values
            GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

            timeOfDay = TimeManagerScript.timeOfDay;

        } else if ((TimeManagerScript.timeOfDay > 82800 && TimeManagerScript.timeOfDay <= 86400) || (TimeManagerScript.timeOfDay >= 0  && TimeManagerScript.timeOfDay <= 3600))
        {

            /*float speed = GameObject.Find("Background").GetComponent<TimeManagerScript>().speed;
            timeOfDay += Time.deltaTime * speed;

            frac = (timeOfDay - 82800) / 7200;*/

            if (TimeManagerScript.timeOfDay >= 82800 && TimeManagerScript.timeOfDay < 86400)
            {
                frac = (TimeManagerScript.timeOfDay - 82800) / 7200; 
            } else if (TimeManagerScript.timeOfDay >= 0 && TimeManagerScript.timeOfDay <= 3600)
            {
                frac = (TimeManagerScript.timeOfDay + 3600) / 7200;
            }

            x = Mathf.Lerp(Mathf.Sqrt(342.25f - (endY + 5) * (endY + 5)) - 12f, -Mathf.Sqrt(342.25f - (endY + 5) * (endY + 5)) + 6f, frac);
            y = Mathf.Sqrt(169f - (x + 3) * (x + 3)) - 5f;

            GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

        } else if (TimeManagerScript.timeOfDay > 3600 && TimeManagerScript.timeOfDay <= sun.GetComponent<SunPathScript>().riseTimeHr * 60 *60)
        {

            frac = (TimeManagerScript.timeOfDay - 3600) / (sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60 - 3600);
            y = Mathf.Lerp(endY, startY, frac);

            //Value of x calculated using the curve (x + 12)^2 + (y + 5)^2 = 18.5^2
            x = -Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) + 6f;

            //sun position set according to the x and y values
            GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

        }
        else
        {
            //Resetting position
            y = startY;
            GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
        }

        //to avoid reflections below horizon
        if (GetComponent<Transform>().position.y >= horizon - 1f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
