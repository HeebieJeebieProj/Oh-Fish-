using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudColorScript : MonoBehaviour {

    public Color[] colors;
    public GameObject sun;
    public GameObject moon;

    private float frac;

	// Use this for initialization
	void Start () {
		
        if (TimeManagerScript.timeOfDay > 0 && TimeManagerScript.timeOfDay <= sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60)
        {
            frac = TimeManagerScript.timeOfDay / (sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[0], colors[1], frac);
        } else if (TimeManagerScript.timeOfDay > sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60 && TimeManagerScript.timeOfDay <= 43200)    
        {
            frac = (TimeManagerScript.timeOfDay - sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60) / (43200 - sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[1], colors[2], frac);
        } else if (TimeManagerScript.timeOfDay > 43200 && TimeManagerScript.timeOfDay <= moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - 43200) / (moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60 - 43200);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[2], colors[3], frac);
        } else
        {
            frac = (TimeManagerScript.timeOfDay - moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60) / (86400 - moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[3], colors[0], frac);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (TimeManagerScript.timeOfDay > 0 && TimeManagerScript.timeOfDay <= sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60)
        {
            frac = TimeManagerScript.timeOfDay / (sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[0], colors[1], frac);
        }
        else if (TimeManagerScript.timeOfDay > sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60 && TimeManagerScript.timeOfDay <= 43200)
        {
            frac = (TimeManagerScript.timeOfDay - sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60) / (43200 - sun.GetComponent<SunPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[1], colors[2], frac);
        }
        else if (TimeManagerScript.timeOfDay > 43200 && TimeManagerScript.timeOfDay <= moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - 43200) / (moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60 - 43200);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[2], colors[3], frac);
        }
        else
        {
            frac = (TimeManagerScript.timeOfDay - moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60) / (86400 - moon.GetComponent<MoonPathScript>().riseTimeHr * 60 * 60);
            GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().color = Color.Lerp(colors[3], colors[0], frac);
        }

    }
}
