using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunReflectionScript : MonoBehaviour {

    public float horizon;

    private float y;
    private float x;

	// Use this for initialization
	void Start () {
		
        if (SunPathScript.y >= horizon - 1f)
        {

            y = horizon + 0.3f + (SunPathScript.y - (horizon - 1f)) * -0.3f;

        } else
        {

            y = horizon;

        }

        x = SunPathScript.x;

        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);
	}
	
	// Update is called once per frame
	void Update () {

        if (SunPathScript.y >= horizon - 1f)
        {

            y = horizon + 0.3f + (SunPathScript.y - (horizon - 1f)) * -0.3f;
            Debug.Log(SunPathScript.y + " " + y);
        }
        else
        {

            y = horizon;

        }

        x = SunPathScript.x;

        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

    }
}
