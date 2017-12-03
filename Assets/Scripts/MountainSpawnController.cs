using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpawnController : MonoBehaviour {

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

    public static bool shouldSpawn; //For continuous spawning
    public static bool spawnEnd; //For end spawning

    // Use this for initialization
    void Start () {

        shouldSpawn = true;
        spawnEnd = false;
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
            mountainClone.GetComponent<ScrollScript>().speed = speed;
            mountainClone.GetComponent<ScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
            mountainClone.GetComponent<ScrollScript>().mountain = mountainSprite;

            mountainClone = Instantiate(mountainReflection, new Vector3(-xDiff, mountainReflection.GetComponent<Transform>().position.y, mountainReflection.GetComponent<Transform>().position.z), mountainReflection.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponent<SpriteRenderer>().sprite = endMountainSprite;
            mountainClone.GetComponent<ScrollScript>().speed = speed;
            mountainClone.GetComponent<ScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<ScrollScript>().endMountainSprite = endMountainSprite;
            mountainClone.GetComponent<ScrollScript>().mountain = mountainSprite;

            mountainClone = Instantiate(mountainReflectionWhite, new Vector3(-xDiff, mountainReflectionWhite.GetComponent<Transform>().position.y, mountainReflectionWhite.GetComponent<Transform>().position.z), mountainReflectionWhite.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponent<SpriteRenderer>().sprite = endMountainSpriteWhite;
            mountainClone.GetComponent<ScrollScript>().speed = speed;
            mountainClone.GetComponent<ScrollScript>().xDiff = xDiff;
            mountainClone.GetComponent<ScrollScript>().endMountainSprite = endMountainSpriteWhite;
            mountainClone.GetComponent<ScrollScript>().mountain = mountainSpriteWhite;
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

        StartCoroutine(WaitForTimeDiff());

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
