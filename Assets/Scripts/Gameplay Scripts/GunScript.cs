using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public GameObject Bullet;
    public Transform bulletSpawnPoint;
    public Transform rotationIndicator;
    public GameObject canonFire;
    public Transform canonFireSpawnPoint;

    private Touch touch;
    private Vector3 touchPos;

    private int restoreRotation;
    Quaternion originalRotation;
    public Transform markerDown;
    public Transform markerUp;
    float reverse;

    Quaternion bulletRotation;

    public float speed;

    public Text ComboText;

    float rotateAngle;

    private ObjectPooler objectPooler;
    private HookManagerScript hookManagerScript;

    // Use this for initialization
    void Start () {

        restoreRotation = 0;
        originalRotation = transform.rotation;
        reverse = 7f;
        objectPooler = ObjectPooler.Instance;
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !GameoverScript.gameover && hookManagerScript.hasSetup)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x >= -8 && touchPos.x <= -6.47 && touchPos.y >= -4.5 && touchPos.y <= -3.43)
            {
                GameObject canonFireInstantiated = Instantiate(canonFire, canonFireSpawnPoint);
                canonFireInstantiated.transform.SetParent(GameObject.Find("canon").transform, false);
                canonFireInstantiated.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 2000f, ForceMode2D.Force);
            }
            else
            {
                
                touchPos.z = transform.position.z;
                touchPos.x = Mathf.Clamp(touchPos.x, -3.5f, touchPos.x);
                touchPos.y = Mathf.Clamp(touchPos.y, transform.position.y, touchPos.y);

                if (touchPos.x > transform.position.x)
                {
                    float angle = Mathf.Atan2((touchPos.y - transform.position.y), (touchPos.x - transform.position.x)) * 45f;
                    bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    transform.Rotate(Vector3.forward, angle);

                    GameObject bullet = objectPooler.SpawnFromPool(StringConsants.stringBullets, bulletSpawnPoint.position, bulletRotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(
                        (touchPos - transform.position).normalized * speed,
                        ForceMode2D.Force
                    );
                    bullet.GetComponent<BulletScript>().comboText = ComboText;
                }
            }
            
        }

        if (reverse <= 1.2f)
        {
            restoreRotation = 0;
            reverse = 4f;
        }

    }

    private void FixedUpdate()
    {
        if (restoreRotation == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 5f);
        }
        else if (restoreRotation == 1 && reverse > 0)
        {
            float angle = Quaternion.Angle(originalRotation, transform.rotation);
            if (angle <= 85f)
            {
                transform.Rotate(Vector3.forward, rotateAngle * rotationFactor(new Ray2D(transform.position, rotationIndicator.position), touchPos));
            }
            reverse -= Time.deltaTime * 20f;
        }
    }

    float rotationFactor(Ray2D ray, Vector2 point)
    {
        return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
    }

}
