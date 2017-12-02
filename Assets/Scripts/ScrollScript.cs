using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float xDiff; //Difference between 2 successive objects of same type
    public float speed; //Speed of travel

    private GameObject clone;

    // Use this for initialization
    void Start()
    {

        //Clone when at x = 0
        if (GetComponent<Transform>().position.x >= 0)
        {
            clone = Instantiate(gameObject);
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        } else
        {
            //set clone to null otherwise
            clone = null;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Cloning when at x = 0
        if (clone == null && GetComponent<Transform>().position.x >= 0)
        {
            clone = Instantiate(gameObject);
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            clone.GetComponent<ScrollScript>().speed = speed;
            clone.GetComponent<ScrollScript>().xDiff = xDiff;
        }

        //travel with speed along x
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.001f * speed, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        //Checking for inconsistent x difference between object and it's clone
        if (clone != null && GetComponent<Transform>().position.x - clone.GetComponent<Transform>().position.x != xDiff)
        {
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        }

        //If beyond x = xDiff, destroy the object
        if (GetComponent<Transform>().position.x >= xDiff)
        {
            Destroy(gameObject);
        }

    }
}
