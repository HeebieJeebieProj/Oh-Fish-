using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawnScript : MonoBehaviour
{

    public GameObject[] islands;
    public GameObject backRock;
    public Sprite[] rockSprites;
    public float[] yRange;
    public float[] yRockRange;
    public float[] rangeTimeDiff;
    public float speed;

    private bool startSpawn;
    private GameObject island;
    private int index;
    private bool alternate;
    private int previousIsland;

    // Use this for initialization
    void Start()
    {

        startSpawn = true;
        alternate = true;
        previousIsland = -1;

    }


    // Update is called once per frame
    void Update()
    {

        if (startSpawn)
        {

            startSpawn = false;
            StartCoroutine(IslandGenerator());

        }

    }

    IEnumerator IslandGenerator()
    {

        //if (BaitSelectionScript.hasStarted)
        //{
        if (alternate)
        {
            int number = Random.Range(10, 13);
            int foreNumber = Random.Range(2, 5);
            int afterNumber = Random.Range(2, 5);
            float increment = (yRockRange[1] - yRockRange[0]) * 0.067f;
            for (int l = 0; l < number; l++)
            {

                int rockSprite = Random.Range(0, rockSprites.Length);
                backRock.GetComponent<SpriteRenderer>().sprite = rockSprites[rockSprite];
                if (rockSprite <= 5)
                {
                    backRock.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1f);
                } else
                {
                    backRock.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                }
                backRock.GetComponent<SpriteRenderer>().sortingOrder = l + 2;
                GameObject instanciatedBackRock = Instantiate(
                    backRock,
                    new Vector3(-13f + Camera.main.GetComponent<Transform>().position.x, yRockRange[1] + increment, backRock.GetComponent<Transform>().position.z),
                    backRock.GetComponent<Transform>().rotation
                );

                instanciatedBackRock.transform.parent = GetComponent<Transform>();
                instanciatedBackRock.GetComponent<IslandScrollScript>().speed = speed;

                if (l < foreNumber)
                {
                    yield return new WaitForSeconds(Random.Range(11, 15));
                }
                else if (l >= number - afterNumber)
                {
                    yield return new WaitForSeconds(Random.Range(15, 20));
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(11, 15));
                }

            }

            yield return new WaitForSeconds(
                Random.Range(
                    (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                    (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
                )
            );

        }
        else
        {

            if (previousIsland == -1)
            {
                index = Random.Range(0, 3);
            }
            else
            {
                if (previousIsland == 0)
                {
                    index = Random.Range(1, 3);
                }
                else if (previousIsland == 1)
                {
                    if ((int)Random.Range(0, 2) == 0)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 2;
                    }
                }
                else
                {
                    index = Random.Range(0, 2);
                }
            }

            previousIsland = index;

            if (yRange[2 * index + 1] < yRange[2 * index])
            {
                float temp = yRange[2 * index + 1];
                yRange[2 * index + 1] = yRange[2 * index];
                yRange[2 * index] = temp;
            }

            island = Instantiate(islands[index], new Vector3(-18f + Camera.main.GetComponent<Transform>().position.x, Random.Range(yRange[2 * index], yRange[2 * index + 1]), islands[index].GetComponent<Transform>().position.z), islands[index].GetComponent<Transform>().rotation);
            island.GetComponent<Transform>().parent = GetComponent<Transform>();
            island.GetComponent<IslandScrollScript>().speed = speed;

            yield return new WaitForSeconds(
                Random.Range(
                    (rangeTimeDiff[0] < rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1],
                    (rangeTimeDiff[0] >= rangeTimeDiff[1]) ? rangeTimeDiff[0] : rangeTimeDiff[1]
                )
            );

        }

        alternate = !alternate;

        //}
        startSpawn = true;

    }

}
