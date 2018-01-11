using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCycleScript : MonoBehaviour {

    public Sprite[] spritesMoon;

	// Use this for initialization
	void Start () {
		if (TimeManagerScript.dayCount % 2 == 0)
        {
            GetComponent<SpriteRenderer>().sprite = spritesMoon[0];
        } else
        {
            GetComponent<SpriteRenderer>().sprite = spritesMoon[1];
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Transform>().position.y <= GetComponent<MoonPathScript>().horizon)
        {
            if (TimeManagerScript.dayCount % 2 == 0)
            {
                GetComponent<SpriteRenderer>().sprite = spritesMoon[0];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spritesMoon[1];
            }
        }
		
	}
}
