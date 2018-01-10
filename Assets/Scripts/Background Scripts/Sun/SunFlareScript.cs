using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlareScript : MonoBehaviour {

    public Light directionalLight;

    private float fracFlare;
    private float intensity;

	// Use this for initialization
	void Start () {

        if (GetComponent<Transform>().position.y >= GetComponent<SunPathScript>().horizon - 1f)
        {
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.b,
                1
            );
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                1
            );
        }
        else
        {
            fracFlare = (GetComponent<SunPathScript>().horizon - 1f - GetComponent<Transform>().position.y) / (GetComponent<SunPathScript>().horizon - 1f - GetComponent<SunPathScript>().startY);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.b,
                1 - fracFlare
            );
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                1 - fracFlare
            );

        }

    }
	
	// Update is called once per frame
	void Update () {


        if (GetComponent<Transform>().position.y <= GetComponent<SunPathScript>().horizon - 1f)
        {

            fracFlare = (GetComponent<SunPathScript>().horizon - 1f - GetComponent<Transform>().position.y) / (GetComponent<SunPathScript>().horizon - 1f - GetComponent<SunPathScript>().startY);
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.b,
                1 - fracFlare
            );
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                1 - fracFlare
            );

            intensity = Mathf.Lerp(0, 0.05f, 1 - fracFlare);
            directionalLight.intensity = intensity;

        }
        else if (GetComponent<Transform>().position.y <= 0 && GetComponent<Transform>().position.y > GetComponent<SunPathScript>().horizon - 1f)
        {

            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.b,
                1
            );
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                1
            );

        } else
        {

            fracFlare = (5f - GetComponent<Transform>().position.y) / 5f;
            GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.b,
                Mathf.Clamp(fracFlare, 0.5f, 1f)
            );
            GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.r,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.g,
                GetComponent<Transform>().Find("flare2").GetComponent<SpriteRenderer>().color.b,
                fracFlare
            );

            intensity = Mathf.Lerp(0.05f, 0.15f, 1 - fracFlare);
            directionalLight.intensity = intensity;

        }


    }
}
