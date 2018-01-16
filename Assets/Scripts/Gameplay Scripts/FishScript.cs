using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour {

    public bool touchedBait = false;
    public GameObject bait;
    public bool collided = false;
    public bool inverted;
    public Text text;

    // Use this for initialization
    void Start()
    {
        touchedBait = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (
            GameObject.Find("bait1(Clone)") != null &&
            GameObject.Find("bait1(Clone)").GetComponent<BaitScript>().initialCount <= 0 &&
            (gameObject.name == "Fish1L(Clone)" || gameObject.name == "Fish1R(Clone)") &&
            GetComponent<Rigidbody2D>().velocity == Vector2.zero
          )
        {
            Destroy(gameObject);
        }
        if (
            GameObject.Find("bait2(Clone)") != null &&
            GameObject.Find("bait2(Clone)").GetComponent<BaitScript>().initialCount <= 0 &&
            (gameObject.name == "Fish2L(Clone)" || gameObject.name == "Fish2R(Clone)") &&
            GetComponent<Rigidbody2D>().velocity == Vector2.zero
          )
        {
            Destroy(gameObject);
        }
        if (
            GameObject.Find("bait3(Clone)") != null &&
            GameObject.Find("bait3(Clone)").GetComponent<BaitScript>().initialCount <= 0 &&
            (gameObject.name == "Fish3L(Clone)" || gameObject.name == "Fish3R(Clone)") &&
            GetComponent<Rigidbody2D>().velocity == Vector2.zero
          )
        {
            Destroy(gameObject);
        }
        if (
            GameObject.Find("bait4(Clone)") != null &&
            GameObject.Find("bait4(Clone)").GetComponent<BaitScript>().initialCount <= 0 &&
            (gameObject.name == "Fish4L(Clone)" || gameObject.name == "Fish4R(Clone)") &&
            GetComponent<Rigidbody2D>().velocity == Vector2.zero
          )
        {
            Destroy(gameObject);
        }
        if (
            GameObject.Find("bait5(Clone)") != null &&
            GameObject.Find("bait5(Clone)").GetComponent<BaitScript>().initialCount <= 0 &&
            (gameObject.name == "Fish5L(Clone)" || gameObject.name == "Fish5R(Clone)") &&
            GetComponent<Rigidbody2D>().velocity == Vector2.zero
          )
        {
            Destroy(gameObject);
        }*/

        if (GameoverScript.gameover)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
        }

        if (touchedBait && !GameoverScript.gameover)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("bait").GetComponent<Collider2D>());
        }

        if (transform.position.y <= -10f || transform.position.y >= 5.6f || transform.position.x <= -8f || transform.position.x >= 9f)
        {
            Destroy(gameObject);
            FishCountScript.DecreaseCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            collided = true;
            /*if (transform.position.y <= -1.5f)
            {
                if (inverted)
                {
                    if (transform.rotation.z >= 0f) text.GetComponent<LogTextAccessorScript>().showText("Critical Catch");
                    else text.GetComponent<LogTextAccessorScript>().showText("Early Catch");
                }
                else
                {
                    if (transform.rotation.z >= 0f) text.GetComponent<LogTextAccessorScript>().showText("Early Catch");
                    else text.GetComponent<LogTextAccessorScript>().showText("Critical Catch");
                }
            }*/
        }
    }

}
