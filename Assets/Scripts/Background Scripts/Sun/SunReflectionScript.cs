using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunReflectionScript : MonoBehaviour {

    public float horizon; //Horizon x value

    //For calculating intermediate position of reflection
    private float y;
    private float x;

	// Use this for initialization
	void Start () {
		
        if (SunPathScript.y >= horizon - 1f)
        {
            //setting y to 0.3 time distance from horizon as sun
            y = horizon + 0.3f + (SunPathScript.y - (horizon - 1f)) * -0.3f;

        } else
        {
            //setting y = horizon when sun hasn't risen above horizon
            y = horizon;

        }

        //setting x equal to that of sun
        x = SunPathScript.x;

        //setting final position
        GetComponent<Transform>().position = new Vector3(x + Camera.main.GetComponent<Transform>().position.x, y, GetComponent<Transform>().position.z);
	}
	
	// Update is called once per frame
	void Update () {

        if (SunPathScript.y >= horizon - 1f && SunPathScript.y <= horizon)
        {
            y = horizon;
            float frac = 1 - (horizon - SunPathScript.y);
            GetComponent<Transform>().localScale = new Vector3(frac * 2, frac * 0.3f, 1f);
        }
        else if (SunPathScript.y > horizon)
        {
            //setting y to 0.3 time distance from horizon as sun
            y = horizon + 0.3f + (SunPathScript.y - (horizon - 1f)) * -0.3f;
        }
        else
        {
            //setting y = horizon when sun hasn't risen above horizon
            y = horizon;
            GetComponent<Transform>().localScale = new Vector3(0, 0, 1f);
        }

        //setting x equal to that of sun
        x = SunPathScript.x;

        //setting final position
        GetComponent<Transform>().position = new Vector3(x + Camera.main.GetComponent<Transform>().position.x, y, GetComponent<Transform>().position.z);

    }
}
