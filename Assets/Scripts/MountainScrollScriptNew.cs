using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainScrollScriptNew : MonoBehaviour {

    public float speed;
    
	// Update is called once per frame
	void Update () {

        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.001f * speed, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        if (GetComponent<Transform>().position.x >= 12f)
        {
            Destroy(gameObject);
        }

    }
}
