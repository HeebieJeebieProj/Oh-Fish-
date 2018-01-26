﻿using System.Collections;
using UnityEngine;

public class CrabSpawnScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] crab;
    public float[] rangeTimeDiff;
    public float speedVertical;
    public float speedHorizontal;
    HookManagerScript hookManagerScript;

    public int[] baitOrder;
    private bool spawnCrab;

	// Use this for initialization
	void Start () {
        spawnCrab = true;
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();
        baitOrder = new int[5];
        int k = 0;
        for (int i = 0; i < hookManagerScript.numberOfHooksActive; i++)
        {
            if(hookManagerScript.baitOrder[i] - 1 >= 0)
            {
                baitOrder[k] = hookManagerScript.baitOrder[i];
                k++;
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (spawnCrab)
        {
            spawnCrab = false;
            StartCoroutine(CrabWaitCycle());
        }
    }

    IEnumerator CrabWaitCycle()
    {
        float time = Random.Range(rangeTimeDiff[0], rangeTimeDiff[1]);
        yield return new WaitForSeconds(time);

        int index = (int) Random.Range(0, hookManagerScript.hooksActive);

        float x = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.y);

        GameObject crabClone = Instantiate(
            crab[baitOrder[index] - 1],    
            new Vector3( x, -5f, crab[0].GetComponent<Transform>().position.z),
            crab[0].GetComponent<Transform>().rotation
        );

        if (x <= 0)
        {

            crabClone.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper(), 2.7f * speedVertical),
                ForceMode2D.Force
            );

        } else
        {

            crabClone.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(speedHorizontalMapper() * -1f, 2.7f * speedVertical),
                ForceMode2D.Force
            );

        }

        spawnCrab = true;
    }

    float speedHorizontalMapper()
    {
        return (3.6f) * (3.6f) * speedHorizontal * 10f;
    }
}
