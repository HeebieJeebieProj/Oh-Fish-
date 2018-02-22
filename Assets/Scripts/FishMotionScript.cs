using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMotionScript : MonoBehaviour {

    public float initForce;
    public float gravityscale;
    public float x;
    public float waitTime;
    public float speedVertical;

    private bool startWaitFin;

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().AddForce(
                new Vector2(initForce * 100f, 0),
                ForceMode2D.Force
            );
        StartCoroutine(StartWait());
        StartCoroutine(Bounce());
        startWaitFin = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        /*if (GetComponent<Transform>().position.y >= -4.8f && GetComponent<Transform>().position.x <= x - 4f)
        {

            GetComponent<Rigidbody2D>().AddForce(
                    new Vector2(initForce * 100f, 0f),
                    ForceMode2D.Force
                );
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f);

        } else
        {

            if (GetComponent<Transform>().position.x > x - 4f && GetComponent<Transform>().position.x <= x)
            {
                GetComponent<Rigidbody2D>().gravityScale = gravityscale * 10f;
                GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(- GetComponent<Rigidbody2D>().velocity.x * 0.1f, 0f),
                        ForceMode2D.Force
                    );
            }
            /*else if (GetComponent<Transform>().position.x <= x + 1f && GetComponent<Transform>().position.x >= x)
            {
                GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(initForce * 0.1f, initForce * 0.1f),
                        ForceMode2D.Force
                    );
            } else if (GetComponent<Transform>().position.x == x + 2f)
            {

                GetComponent<Rigidbody2D>().gravityScale = 0f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            if (GetComponent<Rigidbody2D>().velocity.magnitude < 1.5f)
            {
                GetComponent<Rigidbody2D>().gravityScale = gravityscale;
                GetComponent<Rigidbody2D>().drag = 1.25f;
                GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(initForce * 80f, initForce * 100f),
                        ForceMode2D.Force
                    );
            }

            Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);

        }*/


    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(waitTime);

        startWaitFin = true;

        yield return new WaitForSeconds(1);

        GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0, initForce * - 50f),
                ForceMode2D.Force
            );

        yield return new WaitForSeconds(0.5f);

        GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0, 2.7f * speedVertical),
                ForceMode2D.Force
            );
        
    }

    IEnumerator Bounce()
    {
        yield return new WaitForSeconds(1);

        while(!startWaitFin)
        {
            GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0, initForce * - 30f),
                ForceMode2D.Force
            );

            yield return new WaitForSeconds(1.5f);
        }
    }

}
