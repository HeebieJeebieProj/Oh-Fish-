﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScrollScript : MonoBehaviour, InterfacePooledObject {

    public float speed;

    private float sp;

    private ObjectPooler objectPooler;

    public void OnObjectSpawn()
    {

        objectPooler = ObjectPooler.Instance;

    }

    // Update is called once per frame
    void Update () {

        sp = speed * 60 / MobileUtilsScript.FramesPerSec;

        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.005f * sp, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        if (GetComponent<Transform>().position.x >= 18f + Camera.main.GetComponent<Transform>().position.x)
        {
            objectPooler.EnqueueToPool(StringConsants.StringMapper(gameObject.name), gameObject);
        }
		
	}
}
