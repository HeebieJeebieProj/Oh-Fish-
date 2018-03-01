using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour, InterfacePooledObject {

    public Text baitNumber;
    public int initialCount;
    public int baitNum;

    private ObjectPooler objectPooler;

	// Use this for initialization
	public void OnObjectSpawn () {

        objectPooler = ObjectPooler.Instance;

	}
	
	// Update is called once per frame
	void Update () {
        baitNumber.text = initialCount.ToString();
        if (initialCount <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            baitNumber.enabled = false;
        } else
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if (GameoverScript.gameover)
        {
            objectPooler.EnqueueToPool(StringConsants.stringBaits, gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameoverScript.replayActive)
        {
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
            initialCount--;
        } else
        {
            FishScript fishScript = collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>();
            if (baitNum == 0)
            {
                if (fishScript.fishNumber == 0 && !fishScript.touchedBait && !fishScript.collided)
                {
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                    initialCount--;
                }
            }
            else if (baitNum == 1)
            {
                if (fishScript.fishNumber == 1 && !fishScript.touchedBait && !fishScript.collided)
                {
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                    initialCount--;
                }
            }
            else if (baitNum == 2)
            {
                if (fishScript.fishNumber == 2 && !fishScript.touchedBait && !fishScript.collided)
                {
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                    initialCount--;
                }
            }
            else if (baitNum == 3)
            {
                if (fishScript.fishNumber == 3 && !fishScript.touchedBait && !fishScript.collided)
                {
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                    initialCount--;
                }
            }
            else if (baitNum == 4)
            {
                if (fishScript.fishNumber == 4 && !fishScript.touchedBait && !fishScript.collided)
                {
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                    collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                    initialCount--;
                }
            }
            else if (baitNum == 5)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        }
    }
}
