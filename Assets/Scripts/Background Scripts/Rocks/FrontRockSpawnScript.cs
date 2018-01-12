using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontRockSpawnScript : MonoBehaviour {

    public GameObject frontRock;
    public Sprite[] rockSprites;
    public float speed;
    public float[] yRange;
    public float[] timeDiffRange;

    private bool startSpawn;

	// Use this for initialization
	void Start () {

        startSpawn = true;

	}
	
	// Update is called once per frame
	void Update () {

        if (startSpawn)
        {

            startSpawn = false;
            StartCoroutine(SpawnRock());

        }
		
	}

    IEnumerator SpawnRock()
    {

        yield return new WaitForSeconds(Random.Range(timeDiffRange[0], timeDiffRange[1]));

        int index = (int) Random.Range(0, rockSprites.Length);

        GameObject frontRockClone = Instantiate(
            frontRock,
            new Vector3(-12f + Camera.main.GetComponent<Transform>().position.x, Random.Range(yRange[0], yRange[1]), frontRock.GetComponent<Transform>().position.z),
            frontRock.GetComponent<Transform>().rotation
        );
        frontRockClone.GetComponent<SpriteRenderer>().sprite = rockSprites[index];
        frontRockClone.GetComponent<Transform>().parent = GetComponent<Transform>();
        frontRockClone.GetComponent<ScrollScript>().speed = speed;

    }

}
