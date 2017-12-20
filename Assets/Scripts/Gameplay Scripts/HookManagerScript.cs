using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManagerScript : MonoBehaviour {

    public int numberOfHooksActive;
    public Transform[] hookPositions;
    public Transform[] spawnPoints;
    public GameObject[] hooks;

    private bool setup;
    private int i;

	// Use this for initialization
	void Start () {

        setup = true;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (setup)
        {

            setup = false;

            for (i = 0; i < hooks.Length; i++)
            {
                if (i <= numberOfHooksActive - 1)
                {
                    hooks[i].SetActive(true);
                }
                else
                {
                    hooks[i].SetActive(false);
                }
            }

            switch (numberOfHooksActive)
            {

                case 1:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[0].position.x, 
                            hooks[0].GetComponent<Transform>().position.y, 
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        Transform[] spawnPoint = new Transform[2];
                        spawnPoint[0] = spawnPoints[0];
                        spawnPoint[1] = spawnPoints[1];

                        hooks[0].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                    } break;

                case 2:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[1].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        Transform[] spawnPoint = new Transform[2];
                        spawnPoint[0] = spawnPoints[2];
                        spawnPoint[1] = spawnPoints[3];

                        hooks[0].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[2].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );
                        
                        spawnPoint[0] = spawnPoints[4];
                        spawnPoint[1] = spawnPoints[5];

                        hooks[1].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                    } break;

                case 3:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[3].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        Transform[] spawnPoint = new Transform[2];
                        spawnPoint[0] = spawnPoints[6];
                        spawnPoint[1] = spawnPoints[7];
                        Debug.Log(spawnPoint[0].position.x + " " + spawnPoint[1].position.x);

                        hooks[0].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[4].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[8];
                        spawnPoint[1] = spawnPoints[9];
                        Debug.Log(spawnPoint[0].position.x + " " + spawnPoint[1].position.x);

                        hooks[1].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[5].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[10];
                        spawnPoint[1] = spawnPoints[11];
                        Debug.Log(spawnPoint[0].position.x + " " + spawnPoint[1].position.x);

                        hooks[2].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                    } break;

                case 4:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[6].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        Transform[] spawnPoint = new Transform[2];
                        spawnPoint[0] = spawnPoints[12];
                        spawnPoint[1] = spawnPoints[13];

                        hooks[0].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[7].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[14];
                        spawnPoint[1] = spawnPoints[15];

                        hooks[1].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[8].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[16];
                        spawnPoint[1] = spawnPoints[17];

                        hooks[2].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[9].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[18];
                        spawnPoint[1] = spawnPoints[19];

                        hooks[3].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                    } break;

                case 5:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[10].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        Transform[] spawnPoint = new Transform[2];
                        spawnPoint[0] = spawnPoints[20];
                        spawnPoint[1] = spawnPoints[21];

                        hooks[0].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[11].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[22];
                        spawnPoint[1] = spawnPoints[23];

                        hooks[1].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[12].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[24];
                        spawnPoint[1] = spawnPoints[25];

                        hooks[2].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[13].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[26];
                        spawnPoint[1] = spawnPoints[27];

                        hooks[3].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                        hooks[4].GetComponent<Transform>().position = new Vector3(
                            hookPositions[14].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        spawnPoint[0] = spawnPoints[28];
                        spawnPoint[1] = spawnPoints[29];

                        hooks[4].GetComponent<FishSpawnScript>().spawnPoints = spawnPoint;

                    } break;

            }

        }

	}
}
