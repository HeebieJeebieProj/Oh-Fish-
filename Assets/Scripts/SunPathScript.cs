using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPathScript : MonoBehaviour {
    
    public float startY;
    public float startX;
    public float endY;
    public float endX;

    private float y;
    private float x;

	// Use this for initialization
	void Start () {
        GetComponent<Transform>().position = new Vector3(startX, startY, GetComponent<Transform>().position.z);
        y = startY;
	}
	
	// Update is called once per frame
	void Update () {
        y += 0.01f;
        x = -(15f / 144f) * (y + 5) * (y + 5) + 7;
        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);
	}
}
