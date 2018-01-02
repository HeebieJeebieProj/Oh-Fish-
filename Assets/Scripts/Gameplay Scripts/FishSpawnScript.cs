using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnScript : MonoBehaviour {

    public GameObject fish;
    public int baitNumber;
    public Transform baitSpawnPoint;
    public float radius;
    public float speedHorizontal;
    public float speedVertical;
    public float gravityScale;
    public float y;

    private bool spawnOne;
    private bool spawnTwo;
    private bool spawnThree;
    private bool spawnFour;
    private float time;

	// Use this for initialization
	void Start () {

        spawnOne = false;
        spawnTwo = false;
        spawnThree = false;
        spawnFour = false;
        StartCoroutine(StartWait());

	}
	
	// Update is called once per frame
	void Update () {
		
        if (FishCountScript.numberOfActive <= 4)
        {
            if (spawnOne)
            {
                spawnOne = false;
                StartCoroutine(SpawnOne());
            }
            if (spawnTwo)
            {
                spawnTwo = false;
                StartCoroutine(SpawnTwo());
            }
            if (spawnThree)
            {
                spawnThree = false;
                StartCoroutine(SpawnThree());
            }
            if (spawnFour)
            {
                spawnFour = false;
                StartCoroutine(SpawnFour());
            }
        }

        baitSpawnPoint = GetComponent<Transform>().Find("baitSpawnPoint").GetComponent<Transform>();

	}

    IEnumerator StartWait()
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
        time = Random.Range(2, 5);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive <= 4)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                GameObject fishClone = (GameObject)Instantiate(
                    fish,
                    new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                    fish.GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                GameObject fishClone = (GameObject)Instantiate(
                   fish,
                   new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                   fish.GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            FishCountScript.IncreaseCount();

        }

        spawnOne = true;

    }

    IEnumerator SpawnTwo ()
    {

        time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive <= 4)
        {


            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                GameObject fishClone = (GameObject)Instantiate(
                    fish,
                    new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                    fish.GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                GameObject fishClone = (GameObject)Instantiate(
                   fish,
                   new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                   fish.GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            FishCountScript.IncreaseCount();

        } 

        spawnTwo = true;

    }

    IEnumerator SpawnThree()
    {

        time = Random.Range(4, 7);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive <= 4)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                GameObject fishClone = (GameObject)Instantiate(
                    fish,
                    new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                    fish.GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                GameObject fishClone = (GameObject)Instantiate(
                   fish,
                   new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                   fish.GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            FishCountScript.IncreaseCount();

        }

        spawnThree = true;

    }

    IEnumerator SpawnFour ()
    {

        time = Random.Range(5, 10);
        yield return new WaitForSeconds(time);

        //int index;

        if (FishCountScript.numberOfActive <= 4)
        {

            float x = Random.Range(baitSpawnPoint.position.x - radius, baitSpawnPoint.position.x + radius);

            if (x < baitSpawnPoint.position.x)
            {
                GameObject fishClone = (GameObject)Instantiate(
                    fish,
                    new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                    fish.GetComponent<Transform>().rotation
                );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform), 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
            else
            {
                GameObject fishClone = (GameObject)Instantiate(
                   fish,
                   new Vector3(x, y, fish.GetComponent<Transform>().position.z),
                   fish.GetComponent<Transform>().rotation
               );
                fishClone.GetComponent<Rigidbody2D>().AddForce(
                            new Vector2(speedHorizontalMapper(fishClone.transform) * -1f, 2.7f * speedVertical),
                            ForceMode2D.Force
                        );
                fish.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
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
