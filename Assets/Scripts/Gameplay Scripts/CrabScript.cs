using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : MonoBehaviour, InterfacePooledObject {

    public int crabNumber;

    private ObjectPooler objectPooler;

	// Use this for initialization
	public void OnObjectSpawn () {

        objectPooler = ObjectPooler.Instance;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (GetComponent<Transform>().position.y <= -6f)
        {
            objectPooler.EnqueueToPool(StringConsants.stringCrabs, gameObject);
        }

	}
}
