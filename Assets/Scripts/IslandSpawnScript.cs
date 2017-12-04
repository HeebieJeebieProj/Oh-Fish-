using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawnScript : MonoBehaviour {

    public GameObject[] islands;
    public float[] yRange;
    public float[] rangeTimeDiff;
    public float speed;

    private bool startSpawn;
    private GameObject island;
    private int index;

	// Use this for initialization
	void Start () {

        startSpawn = true;
	}

	
	// Update is called once per frame
	void Update () {
	
        if (startSpawn)
        {
            
            startSpawn = false;
            StartCoroutine(IslandGenerator());

        }

	}

    IEnumerator IslandGenerator()
    {

        index = Random.Range(0, 3);

        if (yRange[2* index + 1] < yRange[2 * index])
        {
            float temp = yRange[2 * index + 1];
            yRange[2 * index + 1] = yRange[2 * index];
            yRange[2 * index] = temp;
        }

        island = Instantiate(islands[index], new Vector3(-18f, Random.Range(yRange[2 * index], yRange[2 * index + 1]), islands[index].GetComponent<Transform>().position.z), islands[index].GetComponent<Transform>().rotation);
        island.GetComponent<Transform>().parent = GetComponent<Transform>();
        island.GetComponent<IslandScrollScript>().speed = speed;

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
            )
        );

    }

}
