using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour, InterfacePooledObject {

    public bool touchedBait = false;
    public GameObject bait;
    public bool collided = false;
    public bool inverted;
    public Text text;
    public int fishNumber;

    private ObjectPooler objectPooler;
    private GameObject[] ignoreCollision;
    private int i;

    // Use this for initialization
    public void OnObjectSpawn()
    {
        touchedBait = false;
        collided = false;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Collider2D>().isTrigger = false;
        objectPooler = ObjectPooler.Instance;
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

        if (transform.position.y <= -10f || transform.position.y >= 5.6f || transform.position.x <= -8f || transform.position.x >= 11f)
        {
            FishCountScript.DecreaseCount();
            objectPooler.EnqueueToPool(StringConsants.stringFishes, gameObject);
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
