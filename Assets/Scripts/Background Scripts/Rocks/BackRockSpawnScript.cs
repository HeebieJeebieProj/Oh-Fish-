using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRockSpawnScript : MonoBehaviour {

    public GameObject backRock;
    public Sprite[] rockSprites;
    public float speed;
    public float y;
    public float[] timeDiffRange;

    private bool startSpawn;

    // Use this for initialization
    void Start()
    {

        startSpawn = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (startSpawn)
        {

            startSpawn = false;
            StartCoroutine(SpawnRock());

        }

    }

    IEnumerator SpawnRock()
    {

        yield return new WaitForSeconds(Random.Range(timeDiffRange[0], timeDiffRange[1]));

        int index = (int)Random.Range(0, rockSprites.Length);

        GameObject frontRockClone = Instantiate(
            backRock,
            new Vector3(-12f + Camera.main.GetComponent<Transform>().position.x, y, backRock.GetComponent<Transform>().position.z),
            backRock.GetComponent<Transform>().rotation
        );
        frontRockClone.GetComponent<SpriteRenderer>().sprite = rockSprites[index];
        frontRockClone.GetComponent<Transform>().parent = GetComponent<Transform>();
        frontRockClone.GetComponent<ScrollScript>().speed = speed;

    }

}
