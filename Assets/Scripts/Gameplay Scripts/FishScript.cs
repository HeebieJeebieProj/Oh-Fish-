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

        //if ()

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
            FishCountScript.DecreaseCount();
            Destroy(gameObject);
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
