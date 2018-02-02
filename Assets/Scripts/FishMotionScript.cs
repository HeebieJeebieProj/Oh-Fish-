using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMotionScript : MonoBehaviour {

    public float initForce;
    public float gravityscale;
    public float x;

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().AddForce(
                new Vector2(initForce * 100f, initForce * 100f),
                ForceMode2D.Force
            );

	}
	
	// Update is called once per frame
	void Update () {
		
        if (GetComponent<Transform>().position.y >= -4.8f && GetComponent<Transform>().position.x <= x - 4f)
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
            }*/ else if (GetComponent<Transform>().position.x == x + 2f)
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

        }


    }
}
