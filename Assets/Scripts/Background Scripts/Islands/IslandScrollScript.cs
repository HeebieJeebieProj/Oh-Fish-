using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScrollScript : MonoBehaviour {

    public float speed;

    private float sp;
	
	// Update is called once per frame
	void Update () {

        sp = speed * 60 / MobileUtilsScript.FramesPerSec;

        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.005f * sp, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        if (GetComponent<Transform>().position.x >= 18f + Camera.main.GetComponent<Transform>().position.x)
        {
            Destroy(gameObject);
        }
		
	}
}
