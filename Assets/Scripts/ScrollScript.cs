using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float xDiff; //Difference between 2 successive objects of same type
    public float speed; //Speed of travel
    public Sprite endMountainSprite;
    public Sprite mountain;

    private GameObject clone; //To keep the clone of present object

    // Use this for initialization
    void Start()
    {

        if (MountainSpawnController.shouldSpawn)
        {

            //Clone when at x = 0
            if (GetComponent<Transform>().position.x >= 0)
            {
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<ScrollScript>().speed = speed;
                clone.GetComponent<ScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = mountain;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<ScrollScript>().mountain = mountain;
            }
            else
            {
                //set clone to null otherwise
                clone = null;
            }

        } else
        {

            if (MountainSpawnController.spawnEnd)
            {

                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<ScrollScript>().speed = speed;
                clone.GetComponent<ScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<ScrollScript>().mountain = mountain;
                clone.GetComponent<SpriteRenderer>().flipY = true;
                MountainSpawnController.spawnEnd = false;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        //Cloning when at x = 0
        if (clone == null && GetComponent<Transform>().position.x >= 0)
        {
            if (MountainSpawnController.shouldSpawn)
            {
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<ScrollScript>().speed = speed;
                clone.GetComponent<ScrollScript>().xDiff = xDiff;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<SpriteRenderer>().sprite = mountain;
                clone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<ScrollScript>().mountain = mountain;
            } else if (MountainSpawnController.spawnEnd)
            {
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<ScrollScript>().speed = speed;
                clone.GetComponent<ScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<SpriteRenderer>().flipY = true;
                clone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<ScrollScript>().mountain = mountain;
                MountainSpawnController.spawnEnd = false;
            }
            
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
