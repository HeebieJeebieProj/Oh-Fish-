using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGradientScript : MonoBehaviour {

    public float alpha;
    public float radius;
    public GameObject sun;

    private float frac;
    private float val;
    private float distance;

	// Use this for initialization
	void Start () {

        distance = Mathf.Sqrt(Mathf.Pow(sun.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x, 2) + Mathf.Pow(sun.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y, 2));
        if (distance <= radius)
        {
            frac = (radius - distance) / radius;
            val = Mathf.Lerp(alpha, 1, frac);
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, val);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
        }

	}
	
	// Update is called once per frame
	void Update () {

        distance = Mathf.Sqrt(Mathf.Pow(sun.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x, 2) + Mathf.Pow(sun.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y, 2));
        Debug.Log(distance);
        if (distance <= radius)
        {
            frac = (radius - distance) / radius;
            val = Mathf.Lerp(alpha, 1, frac);
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, val);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
        }

    }
}
