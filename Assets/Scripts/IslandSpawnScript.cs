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
        
        if (yRange[1] < yRange[0])
        {
            float temp = yRange[1];
            yRange[1] = yRange[0];
            yRange[0] = temp;
        }

        island = islands[Random.Range(0, 3)];
        GameObject islandClone = Instantiate(island, new Vector3(-16f, Random.Range(yRange[0], yRange[1]), island.GetComponent<Transform>().position.z), island.GetComponent<Transform>().rotation);

        yield return new WaitForSeconds(
            Random.Range(
                (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
            )
        );

    }

}
