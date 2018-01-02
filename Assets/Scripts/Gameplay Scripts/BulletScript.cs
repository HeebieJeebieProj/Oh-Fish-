using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        comboStall = false;
        rightThreshold = GameObject.Find("countMarker").GetComponent<Transform>();
        collided = false;
        changeSprite = false;
        moveWith = false;
        moveWithCrab = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (comboStall && collided)
        {
            if (transform.position.x > rightThreshold.position.x && ComboScript.comboActive)
            {
                comboStall = false;
                ComboScript.comboNumber++;
                comboText.GetComponent<ComboScript>().showText(ComboScript.comboNumber.ToString());
            }
        }
        if (ComboScript.comboActive && !collided && (transform.position.x > rightThreshold.position.x || transform.position.y >= 5.1f || transform.position.y <=-5.1f))
        {
            ComboScript.comboActive = false;
            ComboScript.comboNumber = 0;
        }
        if (collided)
        {
            if (fishGameObject != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("fish").GetComponent<Collider2D>());
            }
            if (crabGameObject != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("crab").GetComponent<Collider2D>());
            }
        }
        if ((transform.position.x >= 8f || transform.position.y <= -5f || transform.position.y >= 5f) && !GetComponent<Collider2D>().enabled)
        {
            GetComponent<Collider2D>().enabled = true;
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
                ContactPoint2D contact = fishCollision.contacts[0];
                if (fishGameObject.name == "Fish1L(Clone)" || fishGameObject.name == "Fish1R(Clone)")
                {
                    spriteRenderer.sprite = fishDeadSprite[0];
                }
                else if (fishGameObject.name == "Fish2L(Clone)" || fishGameObject.name == "Fish2R(Clone)")
                {
                    spriteRenderer.sprite = fishDeadSprite[1];
                }
                else if (fishGameObject.name == "Fish3L(Clone)" || fishGameObject.name == "Fish3R(Clone)")
                {
                    spriteRenderer.sprite = fishDeadSprite[2];
                }
                else if (fishGameObject.name == "Fish4L(Clone)" || fishGameObject.name == "Fish4R(Clone)")
                { 
                    spriteRenderer.sprite = fishDeadSprite[3];
                }
                else if (fishGameObject.name == "Fish5L(Clone)" || fishGameObject.name == "Fish5R(Clone)")
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
