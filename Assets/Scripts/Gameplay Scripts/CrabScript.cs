using System.Collections;
using UnityEngine;

public class CrabScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] crab;
    GameObject[] crabList;
    public float speedVertical;
    public float speedHorizontal;
    HookManagerScript hookManagerScript;
    public GameObject shadow;

	// Use this for initialization
	void Start () {
        hookManagerScript = GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>();
        crabList = new GameObject[hookManagerScript.numberOfHooksActive];
        //StartCoroutine(crabWaitCycle());	
	}
	
	// Update is called once per frame
	/*void Update () {
        for (int i = 0; i < hookManagerScript.numberHooks && HookManagerScript.hasSetup; i++)
        {
            if (!GameoverScript.replayActive)
            {
                if (hookManagerScript.baitOrder[i] - 1 >= 0)
                {
                    crabList[i] = crab[hookManagerScript.baitOrder[i] - 1];
                }
            }
        }
    }

    IEnumerator crabWaitCycle ()
    {
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(0);

        while (!GameoverScript.gameover)
        {
            if (BaitSelectionScript.hasStarted)
            {
                float xPos = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x);
                Vector3 spawnPosition = new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y, spawnPoints[0].position.z);

                int index = Random.Range(0, hookManagerScript.numberHooks);

                if (GameoverScript.replayActive)
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    index = Random.Range(0, BaitSelectionScript.numberOfBaitsActive);

                    GameObject crabInstantiated = (GameObject)Instantiate(crab[index], spawnPosition, crab[index].GetComponent<Transform>().rotation);

                    crabInstantiated.transform.SetParent(transform, false);

                    if (spawnPosition.x <= 0)
                    {
                        crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(crabInstantiated.transform), 2.6f * speedVertical),
                            ForceMode2D.Force
                        );
                    }
                    else
                    {
                        crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(crabInstantiated.transform) * -1f, 2.6f * speedVertical),
                            ForceMode2D.Force
                        );
                    }

                } else
                {
                    while (index != hookManagerScript.baitOrder[0] - 1 && index != hookManagerScript.baitOrder[1] - 1 && index != hookManagerScript.baitOrder[2] - 1 && index != hookManagerScript.baitOrder[3] - 1 && index != hookManagerScript.baitOrder[4] - 1)
                    {
                        Random.InitState(System.DateTime.Now.Millisecond);
                        index = Random.Range(0, hookManagerScript.numberHooks);
                    }

                    if ((index == hookManagerScript.baitOrder[0] - 1 || index == hookManagerScript.baitOrder[1] - 1 || index == hookManagerScript.baitOrder[2] - 1 || index == hookManagerScript.baitOrder[3] - 1 || index == hookManagerScript.baitOrder[4] - 1))
                    {
                        int k;
                        if (index == hookManagerScript.baitOrder[0] - 1)
                        {
                            k = 0;
                        }
                        else if (index == hookManagerScript.baitOrder[1] - 1)
                        {
                            k = 1;
                        }
                        else if (index == hookManagerScript.baitOrder[2] - 1)
                        {
                            k = 2;
                        }
                        else if (index == hookManagerScript.baitOrder[3] - 1)
                        {
                            k = 3;
                        }
                        else
                        {
                            k = 4;
                        }
                        GameObject crabInstantiated = (GameObject)Instantiate(crabList[k], spawnPosition, crabList[k].GetComponent<Transform>().rotation);

                        crabInstantiated.transform.SetParent(transform, false);

                        if (spawnPosition.x <= 0)
                        {
                            crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                                new Vector2(speedHorizontalMapper(crabInstantiated.transform), 2.6f * speedVertical),
                                ForceMode2D.Force
                            );
                        }
                        else
                        {
                            crabInstantiated.GetComponent<Rigidbody2D>().AddForce(
                                new Vector2(speedHorizontalMapper(crabInstantiated.transform) * -1f, 2.6f * speedVertical),
                                ForceMode2D.Force
                            );
                        }
                    }

                }

            }

            yield return new WaitForSeconds(Random.Range(2, 3));
        }
    }

    float speedHorizontalMapper(Transform crabTransform)
    {
        return (3.6f) * (3.6f) * speedHorizontal * 10f;
    }*/
}
