using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour {

    public Text baitNumber;
    public int initialCount;

	// Use this for initialization
	void Start () {
        baitNumber.text = initialCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        baitNumber.text = initialCount.ToString();
        if (initialCount <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        } else
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameoverScript.gameover)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "bait1(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish 1 Left(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish 1 Right(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        } else if (gameObject.name == "bait2(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish 2 Left(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish 2 Right(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        }
        else if (gameObject.name == "bait3(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish 3 Left(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish 3 Right(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        }
        else if (gameObject.name == "bait4(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish 4 Left(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish 4 Right(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        }
        else if (gameObject.name == "bait5(Clone)")
        {
            if ((collision.GetComponent<Collider2D>().gameObject.name == "Fish 5 Left(Clone)" || collision.GetComponent<Collider2D>().gameObject.name == "Fish 5 Right(Clone)") && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait && !collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().collided)
            {
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
                collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
                initialCount--;
            }
        } 
        else if (gameObject.name == "bait11(Clone)")
        {
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().touchedBait = true;
            collision.GetComponent<Collider2D>().gameObject.GetComponent<FishScript>().bait = gameObject;
            initialCount--;
        }

    }
}
