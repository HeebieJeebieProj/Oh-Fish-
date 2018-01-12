using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScrollScript : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {

        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.005f * speed, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        if (GetComponent<Transform>().position.x >= 18f + Camera.main.GetComponent<Transform>().position.x)
        {
            Destroy(gameObject);
        }
		
	}
}
