using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnScript : MonoBehaviour
{

    public GameObject[] fish;
    public float[] startWait;
    public int baitNumber;
    public Transform baitSpawnPoint;
    public float radius;
    public float speedHorizontal;
    public float speedVertical;
    public float gravityScale;
    public float y;
    public GameObject shadow;
    public BaitScript baitScript;

    private bool spawnOne;
    private bool spawnTwo;
    private bool spawnThree;
    private bool spawnFour;
    private float time;

    // Use this for initialization
    void Start()
    {

        spawnOne = false;
        spawnTwo = false;
        spawnThree = false;
        spawnFour = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (spawnOne && FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {
            spawnOne = false;
            StartCoroutine(SpawnOne());
        }
        if (spawnTwo && FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {
            spawnTwo = false;
            StartCoroutine(SpawnTwo());
        }
        if (spawnThree && FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {
            spawnThree = false;
            StartCoroutine(SpawnThree());
        }
        if (spawnFour && FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {
            spawnFour = false;
            StartCoroutine(SpawnFour());
        }

        baitSpawnPoint = GetComponent<Transform>().Find("baitSpawnPoint").GetComponent<Transform>();

        Debug.Log(FishCountScript.numberOfActive + " " + FishCountScript.maxFishesDay);

    }

    public IEnumerator StartWait()
    {

        yield return new WaitForSeconds(15);
        spawnOne = true;

        yield return new WaitForSeconds(30);
        spawnTwo = true;

        yield return new WaitForSeconds(45);
        spawnThree = true;

        yield return new WaitForSeconds(60);
        spawnFour = true;

    }

    IEnumerator SpawnOne()
    {
        Random.InitState(Random.Range(0, 100));
        time = Random.Range(2, 5);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);
            float xRange = Random.Range(1f, 2f);
            float yRange = Random.Range(-5f, -4.6f);

            if (x < baitSpawnPoint.position.x)
            {

                x = Mathf.Clamp(x, baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x - 1f);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                    fish[0],
                    new Vector3(x, y, fish[0].GetComponent<Transform>().position.z),
                    fish[0].GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[0].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
                /*x = Mathf.Clamp(x, baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x - 1f);

                /*Instantiate(shadow, new Vector3(x - xRange, -5.5f, shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                    fish[0],
                    new Vector3(x - xRange, y, fish[0].GetComponent<Transform>().position.z),
                    fish[0].GetComponent<Transform>().rotation
                );

                fishClone.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2( 2.5f, 2.5f),
                        ForceMode2D.Force
                    );

                /*fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[0].GetComponent<Rigidbody2D>().gravityScale = gravityScale;*/
            }
            else
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x + 1f, baitSpawnPoint.position.x + radius);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                   fish[1],
                   new Vector3(x, y, fish[1].GetComponent<Transform>().position.z),
                   fish[1].GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[1].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            FishCountScript.IncreaseCount();

        }

        spawnOne = true;

    }

    IEnumerator SpawnTwo()
    {

        Random.InitState(Random.Range(0, 100));
        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {


            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x - 1f);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                    fish[0],
                    new Vector3(x, y, fish[0].GetComponent<Transform>().position.z),
                    fish[0].GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[0].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x + 1f, baitSpawnPoint.position.x + radius);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                   fish[1],
                   new Vector3(x, y, fish[1].GetComponent<Transform>().position.z),
                   fish[1].GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[1].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }

            FishCountScript.IncreaseCount();
        }

        spawnTwo = true;

    }

    IEnumerator SpawnThree()
    {

        Random.InitState(Random.Range(0, 100));
        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x - 1f);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                    fish[0],
                    new Vector3(x, y, fish[0].GetComponent<Transform>().position.z),
                    fish[0].GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[0].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x + 1f, baitSpawnPoint.position.x + radius);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                   fish[1],
                   new Vector3(x, y, fish[1].GetComponent<Transform>().position.z),
                   fish[1].GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[1].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }

            FishCountScript.IncreaseCount();
        }

        spawnThree = true;

    }

    IEnumerator SpawnFour()
    {

        Random.InitState(Random.Range(0, 100));
        time = Random.Range(5, 10);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive < FishCountScript.maxFishesDay && baitScript.initialCount > 0)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x - 1f);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                    fish[0],
                    new Vector3(x, y, fish[0].GetComponent<Transform>().position.z),
                    fish[0].GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[0].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                x = Mathf.Clamp(x, baitSpawnPoint.position.x + 1f, baitSpawnPoint.position.x + radius);

                Instantiate(shadow, new Vector3(x, Random.Range(-4.65f, -5f), shadow.GetComponent<Transform>().position.z), shadow.GetComponent<Transform>().rotation);
                yield return new WaitForSeconds(1);

                GameObject fishClone = (GameObject)Instantiate(
                   fish[1],
                   new Vector3(x, y, fish[1].GetComponent<Transform>().position.z),
                   fish[1].GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish[1].GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }

            FishCountScript.IncreaseCount();
        }

        spawnFour = true;

    }


    float speedHorizontalMapper(Transform fishTransform)
    {
        return (baitSpawnPoint.position.x - fishTransform.position.x) * (baitSpawnPoint.position.x - fishTransform.position.x) * speedHorizontal * 10f;
    }

}
