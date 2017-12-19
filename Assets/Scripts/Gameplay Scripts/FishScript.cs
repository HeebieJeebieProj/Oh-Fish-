using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Transform>().position.y <= -10f)
        {
            Destroy(gameObject);
            FishCountScript.DecreaseCount();
        }
		
	}
}
