using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour {

    public int xx = 1920;
    public int yy = 1080;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(xx, yy, true);
        Camera.main.aspect = 16f / 9f;
	}

}
