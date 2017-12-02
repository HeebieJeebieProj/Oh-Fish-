using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float xDiff;
    public float speed;

    private GameObject clone;

    // Use this for initialization
    void Start()
    {

        if (GetComponent<Transform>().position.x >= 0)
        {
            clone = Instantiate(gameObject);
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        } else
        {
            clone = null;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (clone == null && GetComponent<Transform>().position.x >= 0)
        {
            clone = Instantiate(gameObject);
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
            clone.GetComponent<ScrollScript>().speed = speed;
            clone.GetComponent<ScrollScript>().xDiff = xDiff;
        }

        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.001f * speed, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        if (clone != null && GetComponent<Transform>().position.x - clone.GetComponent<Transform>().position.x != xDiff)
        {
            clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        }

        if (GetComponent<Transform>().position.x >= xDiff)
        {
            Destroy(gameObject);
        }

    }
}
