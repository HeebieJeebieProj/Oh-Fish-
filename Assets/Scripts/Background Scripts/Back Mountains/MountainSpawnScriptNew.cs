using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpawnScriptNew : MonoBehaviour {

    //public float[] rangeTimeDiff; //To accept range time between two successive islands
    public float[] rangeTimeTotal; //To accept range of time for which the islands are seen
    //public float[] rangeTimeTotalDiff; //To accept range of time for two successive range of islands
    public GameObject mountain;
    public Sprite[] mountainSprite;
    public float speed;
    public float x;
    
    public static bool shouldSpawn; //For continuous spawning

    // Use this for initialization
    void Start()
    {

        shouldSpawn = true;

    }

    private void Update()
    {
        
        if (shouldSpawn)
        {

            shouldSpawn = false;
            StartCoroutine(WaitForTimeTotal());

        }

    }

    IEnumerator WaitForTimeTotal()
    {

        //StartCoroutine(WaitForTimeDiff());

        int i = Random.Range(0, mountainSprite.Length / 2);

        GameObject mountainClone = Instantiate(mountain, new Vector3(x, mountain.GetComponent<Transform>().position.y, mountain.GetComponent<Transform>().position.z), mountain.GetComponent<Transform>().rotation);
        mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
        mountainClone.GetComponentInChildren<SpriteRenderer>().sprite = mountainSprite[2 * i];
        mountainClone.GetComponent<ScrollScript>().speed = speed;
        mountainClone.GetComponent<Transform>().Find("mountain").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];
        mountainClone.GetComponent<Transform>().Find("reflection").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeTotal[0] < rangeTimeTotal[1]) ? rangeTimeTotal[0] : rangeTimeTotal[1],
                (rangeTimeTotal[0] >= rangeTimeTotal[1]) ? rangeTimeTotal[0] : rangeTimeTotal[1]
            )
        );

        shouldSpawn = true;

    }

    /*IEnumerator WaitForTimeDiff()
    {

        int i = Random.Range(0, mountainSprite.Length / 2);

        GameObject mountainClone = Instantiate(mountain, new Vector3( x, mountain.GetComponent<Transform>().position.y, mountain.GetComponent<Transform>().position.z), mountain.GetComponent<Transform>().rotation);
        mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
        mountainClone.GetComponentInChildren<SpriteRenderer>().sprite = mountainSprite[2 * i];
        mountainClone.GetComponent<ScrollScript>().speed = speed;
        mountainClone.GetComponent<Transform>().Find("mountain").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];
        mountainClone.GetComponent<Transform>().Find("reflection").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];

        while (shouldSpawn)
        {

            yield return new WaitForSeconds(
                Random.Range(
                    (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                    (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
                )
            );

            i = Random.Range(0, mountainSprite.Length / 2);

            mountainClone = Instantiate(mountain, new Vector3(x, mountain.GetComponent<Transform>().position.y, mountain.GetComponent<Transform>().position.z), mountain.GetComponent<Transform>().rotation);
            mountainClone.GetComponent<Transform>().parent = GetComponent<Transform>();
            mountainClone.GetComponentInChildren<SpriteRenderer>().sprite = mountainSprite[2 * i];
            mountainClone.GetComponent<ScrollScript>().speed = speed;
            mountainClone.GetComponent<Transform>().Find("mountain").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];
            mountainClone.GetComponent<Transform>().Find("reflection").GetComponent<SpriteRenderer>().sprite = mountainSprite[2 * i];

        }
        
    }

    IEnumerator WaitForTimeTotalDiff()
    {

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeTotalDiff[0] < rangeTimeTotalDiff[1]) ? rangeTimeTotalDiff[0] : rangeTimeTotalDiff[1],
                (rangeTimeTotalDiff[0] >= rangeTimeTotalDiff[1]) ? rangeTimeTotalDiff[0] : rangeTimeTotalDiff[1]
            )
        );

        shouldSpawn = true;

        StartCoroutine(WaitForTimeTotal());

    }*/
}
