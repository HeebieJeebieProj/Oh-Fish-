using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunColorScript : MonoBehaviour
{

    public Light directionalLight;

    public Color[] colorSun;
    public Color[] colorFlareSmall;
    public Color[] colorFlareBig;
    public Color[] colorFlare;

    private float frac;
    private Color color;

    // Use this for initialization
    void Start()
    {

        if (GetComponent<Transform>().position.y <= GetComponent<SunPathScript>().horizon - 1f)
        {

            frac = (GetComponent<SunPathScript>().horizon - 1f - GetComponent<Transform>().position.y) / (GetComponent<SunPathScript>().horizon - 1f - GetComponent<SunPathScript>().startY);
            color = Color.Lerp(colorSun[0], colorSun[1], 1 - frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[0], colorFlareSmall[1], 1 - frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[0], colorFlareBig[1], 1 - frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[0], colorFlare[1], 1 - frac);
            directionalLight.color = color;

        }
        else if (GetComponent<Transform>().position.y <= 0 && GetComponent<Transform>().position.y > GetComponent<SunPathScript>().horizon - 1f)
        {

            frac = GetComponent<Transform>().position.y / - (GetComponent<SunPathScript>().horizon - 1f);
            color = Color.Lerp(colorSun[1], colorSun[2], frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[1], colorFlareSmall[2], frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[1], colorFlareBig[2], frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[1], colorFlare[2], frac);
            directionalLight.color = color;

        }
        else
        {

            frac = (5f - GetComponent<Transform>().position.y) / 5f;
            color = Color.Lerp(colorSun[2], colorSun[3], frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[2], colorFlareSmall[3], frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[2], colorFlareBig[3], frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[2], colorFlare[3], frac);
            directionalLight.color = color;

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Transform>().position.y <= GetComponent<SunPathScript>().horizon)
        {

            frac = (GetComponent<SunPathScript>().horizon - GetComponent<Transform>().position.y) / (GetComponent<SunPathScript>().horizon - GetComponent<SunPathScript>().startY);
            color = Color.Lerp(colorSun[0], colorSun[1], 1 - frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[0], colorFlareSmall[1], 1 - frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[0], colorFlareBig[1], 1 - frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[0], colorFlare[1], 1 - frac);
            directionalLight.color = color;

        }
        else if (GetComponent<Transform>().position.y <= 0 && GetComponent<Transform>().position.y > GetComponent<SunPathScript>().horizon)
        {

            frac = (GetComponent<Transform>().position.y - GetComponent<SunPathScript>().horizon) / -GetComponent<SunPathScript>().horizon;
            color = Color.Lerp(colorSun[1], colorSun[2], frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[1], colorFlareSmall[2], frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[1], colorFlareBig[2], frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[1], colorFlare[2], frac);
            directionalLight.color = color;

        }
        else
        {

            frac = GetComponent<Transform>().position.y / 5f;
            color = Color.Lerp(colorSun[2], colorSun[3], frac);
            GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            color = Color.Lerp(colorFlareSmall[2], colorFlareSmall[3], frac);
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlareBig[2], colorFlareBig[3], frac);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                color.r,
                color.g,
                color.b,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a
            );
            color = Color.Lerp(colorFlare[2], colorFlare[3], frac);
            directionalLight.color = color;

        }

    }
}
