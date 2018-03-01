using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour, InterfacePooledObject {

    public int crabNumber;

    private ObjectPooler objectPooler;

	// Use this for initialization
	public void OnObjectSpawn () {

        objectPooler = ObjectPooler.Instance;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Collider2D>().isTrigger = false;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (GetComponent<Transform>().position.y <= -6f)
        {
            objectPooler.EnqueueToPool(StringConsants.stringCrabs, gameObject);
        }

	}
}
