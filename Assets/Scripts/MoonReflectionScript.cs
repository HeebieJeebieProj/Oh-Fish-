﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonReflectionScript : MonoBehaviour
{

    public float horizon; //Horizon x value

    //For calculating intermediate position of reflection
    private float y;
    private float x;

    // Use this for initialization
    void Start()
    {

        if (MoonPathScript.y >= horizon - 1f)
        {
            //setting y to 0.3 time distance from horizon as moon
            y = horizon + 0.3f + (MoonPathScript.y - (horizon - 1f)) * -0.3f;

        }
        else
        {
            //setting y = horizon when moon hasn't risen above horizon
            y = horizon;

        }

        //setting x equal to that of sun
        x = MoonPathScript.x;

        //setting final position
        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (MoonPathScript.y >= horizon - 1f)
        {
            //setting y to 0.3 time distance from horizon as moon
            y = horizon + 0.3f + (MoonPathScript.y - (horizon - 1f)) * -0.3f;
        }
        else
        {
            //setting y = horizon when moon hasn't risen above horizon
            y = horizon;

        }

        //setting x equal to that of sun
        x = MoonPathScript.x;

        //setting final position
        GetComponent<Transform>().position = new Vector3(x, y, GetComponent<Transform>().position.z);

    }
}
