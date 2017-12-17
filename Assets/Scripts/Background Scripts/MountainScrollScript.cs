using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainScrollScript : MonoBehaviour
{

    public float xDiff; //Difference between 2 successive objects of same type
    public float speed; //Speed of travel
    public Sprite endMountainSprite;
    public Sprite mountain;

    private GameObject clone; //To keep the clone of present object
    public bool spawnedEnd;

    // Use this for initialization
    void Start()
    {

        if (MountainSpawnScript.shouldSpawn)
        {

            //Clone when at x = 0
            if (GetComponent<Transform>().position.x >= 0)
            {
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<MountainScrollScript>().speed = speed;
                clone.GetComponent<MountainScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = mountain;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<MountainScrollScript>().mountain = mountain;
                clone.GetComponent<MountainScrollScript>().spawnedEnd = false;
            }
            else
            {
                //set clone to null otherwise
                clone = null;
            }

        } else
        {

            if (MountainSpawnScript.spawnEnd && !spawnedEnd)
            {
                spawnedEnd = true;
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<MountainScrollScript>().speed = speed;
                clone.GetComponent<MountainScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<MountainScrollScript>().mountain = mountain;
                clone.GetComponent<SpriteRenderer>().flipX = true;
                clone.GetComponent<MountainScrollScript>().spawnedEnd = spawnedEnd;
                MountainSpawnScript.i++;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        //Cloning when at x = 0
        if (clone == null && GetComponent<Transform>().position.x >= 0)
        {
            if (MountainSpawnScript.shouldSpawn)
            {
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<MountainScrollScript>().speed = speed;
                clone.GetComponent<MountainScrollScript>().xDiff = xDiff;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<SpriteRenderer>().sprite = mountain;
                clone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<MountainScrollScript>().mountain = mountain;
                clone.GetComponent<MountainScrollScript>().spawnedEnd = false;
            } else if (MountainSpawnScript.spawnEnd && !spawnedEnd)
            {
                spawnedEnd = true;
                clone = Instantiate(gameObject);
                clone.GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - xDiff, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
                clone.GetComponent<MountainScrollScript>().speed = speed;
                clone.GetComponent<MountainScrollScript>().xDiff = xDiff;
                clone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
                clone.GetComponent<Transform>().parent = GetComponent<Transform>().parent;
                clone.GetComponent<SpriteRenderer>().flipX = true;
                clone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
                clone.GetComponent<MountainScrollScript>().mountain = mountain;
                clone.GetComponent<MountainScrollScript>().spawnedEnd = spawnedEnd;
                MountainSpawnScript.i++;
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
