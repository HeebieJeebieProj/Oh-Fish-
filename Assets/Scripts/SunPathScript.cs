using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPathScript : MonoBehaviour {
    
    public float startY; //where the sun starts from
    public float endY; //where the sun should reset it's position in terms of y

    //For calculating intermediate position
    private float y;
    private float x;

	// Use this for initialization
	void Start () {
        y = startY;
        GetComponent<Transform>().position = new Vector3(Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f, startY, GetComponent<Transform>().position.z);
    }
	
	// Update is called once per frame
	void Update () {
   
        y += 0.01f; 
   
        //Value of x calculated using the curve (x + 12)^2 + (y + 5)^2 = 18.5^2
        x = Mathf.Sqrt(342.25f - (y + 5) * (y + 5)) - 12f;

        //Sun position set according to the x and y values
        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

	}
}
