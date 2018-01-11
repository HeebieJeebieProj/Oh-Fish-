using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectColorChangeScript : MonoBehaviour {

    public Color[] colors;
    public float[] time;

    private Color color;
    private float frac;

    // Use this for initialization
    void Start()
    {

        if (TimeManagerScript.timeOfDay > time[0] * 60 * 60 && TimeManagerScript.timeOfDay <= time[1] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[0] * 60 * 60) / (time[1] * 60 * 60 - time[0] * 60 * 60);
            color = Color.Lerp(colors[0], colors[1], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[1] * 60 * 60 && TimeManagerScript.timeOfDay <= time[2] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[1] * 60 * 60) / (time[2] * 60 * 60 - time[1] * 60 * 60);
            color = Color.Lerp(colors[1], colors[2], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[2] * 60 * 60 && TimeManagerScript.timeOfDay <= time[3] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[2] * 60 * 60) / (time[3] * 60 * 60 - time[2] * 60 * 60);
            color = Color.Lerp(colors[2], colors[3], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[3] * 60 * 60 && TimeManagerScript.timeOfDay <= time[4] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[3] * 60 * 60) / (time[4] * 60 * 60 - time[3] * 60 * 60);
            color = Color.Lerp(colors[3], colors[4], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[4] * 60 * 60 && TimeManagerScript.timeOfDay <= time[5] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[4] * 60 * 60) / (time[5] * 60 * 60 - time[4] * 60 * 60);
            color = Color.Lerp(colors[4], colors[5], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if ((TimeManagerScript.timeOfDay > time[5] * 60 * 60 && TimeManagerScript.timeOfDay <= 84600) || (TimeManagerScript.timeOfDay >= 0 && TimeManagerScript.timeOfDay <= time[5] * 60 * 60))
        {
            if (TimeManagerScript.timeOfDay > time[5] * 60 * 60 && TimeManagerScript.timeOfDay <= 84600)
            {
                frac = (TimeManagerScript.timeOfDay - time[5] * 60 * 60) / (84600 - time[5] * 60 * 60 + time[5] * 60 * 60);
            }
            else
            {
                frac = (TimeManagerScript.timeOfDay + 84600 - time[5] * 60 * 60) / (84600 - time[5] * 60 * 60 + time[5] * 60 * 60);
            }
            color = Color.Lerp(colors[5], colors[0], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (TimeManagerScript.timeOfDay > time[0] * 60 * 60 && TimeManagerScript.timeOfDay <= time[1] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[0] * 60 * 60) / (time[1] * 60 * 60 - time[0] * 60 * 60);
            color = Color.Lerp(colors[0], colors[1], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[1] * 60 * 60 && TimeManagerScript.timeOfDay <= time[2] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[1] * 60 * 60) / (time[2] * 60 * 60 - time[1] * 60 * 60);
            color = Color.Lerp(colors[1], colors[2], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[2] * 60 * 60 && TimeManagerScript.timeOfDay <= time[3] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[2] * 60 * 60) / (time[3] * 60 * 60 - time[2] * 60 * 60);
            color = Color.Lerp(colors[2], colors[3], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[3] * 60 * 60 && TimeManagerScript.timeOfDay <= time[4] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[3] * 60 * 60) / (time[4] * 60 * 60 - time[3] * 60 * 60);
            color = Color.Lerp(colors[3], colors[4], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if (TimeManagerScript.timeOfDay > time[4] * 60 * 60 && TimeManagerScript.timeOfDay <= time[5] * 60 * 60)
        {
            frac = (TimeManagerScript.timeOfDay - time[4] * 60 * 60) / (time[5] * 60 * 60 - time[4] * 60 * 60);
            color = Color.Lerp(colors[4], colors[5], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }
        else if ((TimeManagerScript.timeOfDay > time[5] * 60 * 60 && TimeManagerScript.timeOfDay <= 84600) || (TimeManagerScript.timeOfDay >= 0 && TimeManagerScript.timeOfDay <= time[5] * 60 * 60))
        {
            if (TimeManagerScript.timeOfDay > time[5] * 60 * 60 && TimeManagerScript.timeOfDay <= 84600)
            {
                frac = (TimeManagerScript.timeOfDay - time[5] * 60 * 60) / (84600 - time[5] * 60 * 60 + time[5] * 60 * 60);
            }
            else
            {
                frac = (TimeManagerScript.timeOfDay + 84600 - time[5] * 60 * 60) / (84600 - time[5] * 60 * 60 + time[5] * 60 * 60);
            }
            color = Color.Lerp(colors[5], colors[0], frac);
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b);
        }

    }
}
