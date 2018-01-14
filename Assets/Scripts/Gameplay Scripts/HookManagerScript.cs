using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManagerScript : MonoBehaviour {

    public int numberOfHooksActive;
    public int[] baitOrder;
    public GameObject[] fishes;
    public float[] gravity;
    public float[] speedVertical;
    public float[] speedHorizontal;
    public Transform[] hookPositions;
    public float[] radius;
    public GameObject[] hooks;

    private bool setup;
    private int i;
    private GameObject[] fish;

	// Use this for initialization
	void Start () {

        setup = true;
        fish = new GameObject[numberOfHooksActive * 2];

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
                    fish[i * 2] = fishes[(baitOrder[i] - 1) * 2];
                    fish[i * 2 + 1] = fishes[(baitOrder[i] - 1) * 2 + 1];
                    hooks[i].GetComponent<FishSpawnScript>().fish = new GameObject[] { fish[i * 2], fish[i * 2 + 1] };
                    hooks[i].GetComponent<FishSpawnScript>().gravityScale = gravity[baitOrder[i] - 1];
                    hooks[i].GetComponent<FishSpawnScript>().speedHorizontal = speedHorizontal[baitOrder[i] - 1];
                    hooks[i].GetComponent<FishSpawnScript>().speedVertical = speedVertical[baitOrder[i] - 1];
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

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[0];

                    } break;

                case 2:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[1].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[1];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[2].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[1];


                    } break;

                case 3:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[3].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[2];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[4].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[2];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[5].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[2];


                    } break;

                case 4:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[6].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[7].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[8].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[9].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[3].GetComponent<FishSpawnScript>().radius = radius[3];


                    } break;

                case 5:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[10].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[11].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[12].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[13].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[3].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[4].GetComponent<Transform>().position = new Vector3(
                            hookPositions[14].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[4].GetComponent<FishSpawnScript>().radius = radius[4];


                    }
                    break;

            }

        }

	}
}
