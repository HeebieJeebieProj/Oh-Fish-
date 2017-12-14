using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpawnScript : MonoBehaviour {

    public float[] rangeTimeDiff; //To accept range time between to successive islands
    public float[] rangeTimeTotal; //To accept range of time for which the island is seen
    public GameObject mountain;
    public GameObject mountainReflection;
    public GameObject mountainReflectionWhite;
    public Sprite endMountainSprite;
    public Sprite mountainSprite;
    public Sprite endMountainSpriteWhite;
    public Sprite mountainSpriteWhite;
    public float speed;
    public float xDiff;

    public static int i;
    public static bool shouldSpawn; //For continuous spawning
    public static bool spawnEnd; //For end spawning

    // Use this for initialization
    void Start () {

        shouldSpawn = true;
        spawnEnd = false;
        i = 0;
        StartCoroutine(WaitForTimeTotal());

	}

    private void Update()
    {
        
        if (shouldSpawn && spawnEnd)
        {

            spawnEnd = false;

            GameObject mountainClone = Instantiate(mountain, new Vector3(- xDiff, mountain.GetComponent<Transform>().position.y, mountain.GetComponent<Transform>().position.z), mountain.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
            mountainClone.GetComponent<MountainScrollScript>().speed = speed;
            mountainClone.GetComponent<MountainScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
            mountainClone.GetComponent<MountainScrollScript>().mountain = mountainSprite;

            mountainClone = Instantiate(mountainReflection, new Vector3(-xDiff, mountainReflection.GetComponent<Transform>().position.y, mountainReflection.GetComponent<Transform>().position.z), mountainReflection.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
            mountainClone.GetComponent<MountainScrollScript>().speed = speed;
            mountainClone.GetComponent<MountainScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSprite;
            mountainClone.GetComponent<MountainScrollScript>().mountain = mountainSprite;

            mountainClone = Instantiate(mountainReflectionWhite, new Vector3(-xDiff, mountainReflectionWhite.GetComponent<Transform>().position.y, mountainReflectionWhite.GetComponent<Transform>().position.z), mountainReflectionWhite.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponent<SpriteRenderer>().sprite = endMountainSpriteWhite;
            mountainClone.GetComponent<MountainScrollScript>().speed = speed;
            mountainClone.GetComponent<MountainScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<MountainScrollScript>().endMountainSprite = endMountainSpriteWhite;
            mountainClone.GetComponent<MountainScrollScript>().mountain = mountainSpriteWhite;

        }

        if (i == 3)
        {
            i = 0;
            spawnEnd = false;
            StartCoroutine(WaitForTimeDiff());
        } 

    }

    IEnumerator WaitForTimeTotal()
    {

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeTotal[0] < rangeTimeTotal[1]) ? rangeTimeTotal[0] : rangeTimeTotal[1],
                (rangeTimeTotal[0] >= rangeTimeTotal[1]) ? rangeTimeTotal[0] : rangeTimeTotal[1]
            )
        );

        shouldSpawn = false;
        spawnEnd = true;

    }

    IEnumerator WaitForTimeDiff()
    {

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
            )
        );

        shouldSpawn = true;
        spawnEnd = true;

        StartCoroutine(WaitForTimeTotal());

    }
}
