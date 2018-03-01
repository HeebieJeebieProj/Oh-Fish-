using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour, InterfacePooledObject {

    Transform rightThreshold;

    private Transform collisionPoint;
    public Sprite[] fishDeadSprite;
    public Text comboText;

    bool moveWith = false;
    bool moveWithCrab = false;

    GameObject fishGameObject;
    Quaternion rotationFish;
    GameObject crabGameObject;
    Quaternion rotationCrab;

    bool comboStall = false;

    bool collided;

    Collision2D fishCollision;

    bool changeSprite;

    private ObjectPooler objectPooler;
    private GameObject[] ignoreCollision;
    private int i;

    // Use this for initialization
    public void OnObjectSpawn () {

        comboStall = false;
        collided = false;
        changeSprite = false;
        moveWith = false;
        moveWithCrab = false;
        objectPooler = ObjectPooler.Instance;
        fishGameObject = null;
        GetComponent<SpriteRenderer>().enabled = true;
        i = 0;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Collider2D>().isTrigger = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (comboStall && collided)
        {
            if (transform.position.x > 8f && ComboScript.comboActive)
            {
                comboStall = false;
                ComboScript.comboNumber++;
                comboText.GetComponent<ComboScript>().showText(ComboScript.comboNumber.ToString());
            }
        }
        if (ComboScript.comboActive && !collided && (transform.position.x > 8f || transform.position.y >= 5.1f || transform.position.y <=-5.1f))
        {
            ComboScript.comboActive = false;
            ComboScript.comboNumber = 0;
            comboText.GetComponent<ComboScript>().showText(ComboScript.comboNumber.ToString());
        }
        if ((transform.position.x >= 8f || transform.position.y <= -5f || transform.position.y >= 5f) && !GetComponent<Collider2D>().enabled)
        {
            GetComponent<Collider2D>().enabled = true;
        }

        if (transform.position.x >= 10f || transform.position.y >= 6f || transform.position.y <= -6f || transform.position.x <= -10f)
        {

            objectPooler.EnqueueToPool(StringConsants.stringBullets, gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fish")
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            fishGameObject = collision.collider.gameObject;
            fishCollision = collision;
            fishGameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            rotationFish = transform.rotation;
            changeSprite = true;
            fishGameObject.GetComponent<Collider2D>().isTrigger = true;
            collisionPoint = collision.transform;
            projectile();
            collided = true;
            moveWith = true;
            if (ComboScript.comboActive && !comboStall)
            {
                comboStall = true;
            }
            if (!ComboScript.comboActive)
            {
                ComboScript.comboActive = true;
                ComboScript.comboNumber = 0;
                comboStall = true;
            }
        }
        if (collision.collider.tag == "crab")
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            crabGameObject = collision.collider.gameObject;
            crabGameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            rotationCrab = transform.rotation;
            crabGameObject.GetComponent<Collider2D>().isTrigger = true;
            collisionPoint = collision.transform;
            projectile();
            collided = true;
            moveWithCrab = true;
            if (ComboScript.comboActive)
            {
                ComboScript.comboActive = false;
                ComboScript.comboNumber = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveWith && fishGameObject != null)
        {
            fishGameObject.GetComponent<Transform>().position = new Vector3(
                transform.position.x,
                transform.position.y,
                fishGameObject.GetComponent<Transform>().position.z
            );
            fishGameObject.GetComponent<Transform>().rotation = rotationFish;

            if (changeSprite)
            {
                SpriteRenderer spriteRenderer = fishGameObject.GetComponent<SpriteRenderer>();
                FishScript fishScript = fishGameObject.GetComponent<FishScript>();
                if (fishScript.fishNumber == 0)
                {
                    spriteRenderer.sprite = fishDeadSprite[0];
                }
                else if (fishScript.fishNumber == 1)
                {
                    spriteRenderer.sprite = fishDeadSprite[1];
                }
                else if (fishScript.fishNumber == 2)
                {
                    spriteRenderer.sprite = fishDeadSprite[2];
                }
                else if (fishScript.fishNumber == 3)
                { 
                    spriteRenderer.sprite = fishDeadSprite[3];
                }
                else if (fishScript.fishNumber == 4)
                {
                    spriteRenderer.sprite = fishDeadSprite[4];
                }

                changeSprite = false;
            }
        }
        if (moveWithCrab && crabGameObject != null)
        {
            crabGameObject.GetComponent<Transform>().position = new Vector3(
                transform.position.x,
                transform.position.y,
                crabGameObject.GetComponent<Transform>().position.z
            );
            crabGameObject.GetComponent<Transform>().rotation = rotationCrab;
        }
    }

    void projectile()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float velY;
        float velX;
        if (collisionPoint.position.y >= 2f)
        {
            velY = 8f;
            velX = 18f;
        } else
        {
            velY = Mathf.Clamp(30f * (3.43f - collisionPoint.position.y), 8f, 15f);
            velX = Mathf.Clamp(30f * (3.43f - collisionPoint.position.y), 18f, 18f);
        }
        rb.velocity = rb.velocity.normalized + new Vector2(velX, velY);
        rb.gravityScale = 4f;
    }
}
