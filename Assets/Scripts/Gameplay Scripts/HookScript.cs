using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameoverScript.gameover)
        {
            StartCoroutine(WaitDestroy());
        }
		
	}

    IEnumerator WaitDestroy()
    {

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);

    }

}
