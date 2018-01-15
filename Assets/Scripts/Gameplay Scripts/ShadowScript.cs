using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(StartWait());

	}
	
	IEnumerator StartWait()
    {

        yield return new WaitForSeconds(1);

        Destroy(gameObject);

    }
}
