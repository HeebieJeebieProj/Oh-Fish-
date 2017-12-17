using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRendererScript : MonoBehaviour {

    public Transform[] mastJoints;
    public Transform[] hookHangerJoints;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < mastJoints.Length; i++)
        {
            mastJoints[i].GetComponent<LineRenderer>().SetPosition(0, Camera.main.ScreenToWorldPoint(mastJoints[i].position));
            mastJoints[i].GetComponent<LineRenderer>().SetPosition(1, Camera.main.ScreenToWorldPoint(hookHangerJoints[i].position));
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < mastJoints.Length; i++)
        {
            mastJoints[i].GetComponent<LineRenderer>().SetPosition(0, mastJoints[i].position);
            mastJoints[i].GetComponent<LineRenderer>().SetPosition(1, hookHangerJoints[i].position);
        }
    }
}
