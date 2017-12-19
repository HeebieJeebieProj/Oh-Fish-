using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCountScript : MonoBehaviour {

    public static int numberOfActive;

	// Use this for initialization
	void Start () {
        numberOfActive = 0;
	}
	
    public static void IncreaseCount()
    {
        numberOfActive++;
    }

    public static void DecreaseCount()
    {
        numberOfActive--;
    }

}
