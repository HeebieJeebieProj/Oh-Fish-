using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGradientScript : MonoBehaviour {

    public float alpha;
    public float radius;
    public GameObject sun;
    public bool flipped;
    
    private float distance;

	// Use this for initialization
	void Start () {
        distance = Mathf.Sqrt(Mathf.Pow(sun.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x, 2) + Mathf.Pow(sun.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y, 2));
        if (distance <= radius)
        {
            if (GetComponent<Transform>().position.x <= sun.GetComponent<Transform>().position.x)
            {
                if (!flipped)
                {
                    GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color = new Color(
                            GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.r,
                            GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.g,
                            GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.b,
                            alpha
                    );
                }
            } else
            {
                if (flipped)
                {
                    GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color = new Color(
                            GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.r,
                            GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.g,
                            GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.b,
                            alpha
                    );
                }
               
            }
        } else
        {
            GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color = new Color(
                   GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.r,
                   GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.g,
                   GetComponent<Transform>().Find("gradient left").GetComponent<SpriteRenderer>().color.b,
                   alpha
            );
            GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color = new Color(
                   GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.r,
                   GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.g,
                   GetComponent<Transform>().Find("gradient right").GetComponent<SpriteRenderer>().color.b,
                   alpha
            );
        }

	}
	
	// Update is called once per frame
	void Update () {

        distance = Mathf.Sqrt(Mathf.Pow(sun.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x, 2) + Mathf.Pow(sun.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y, 2));
        if (distance <= radius && sun.GetComponent<Transform>().Find("flare1").GetComponent<SpriteRenderer>().color.a == 1)
        {
            if (GetComponent<Transform>().position.x >= sun.GetComponent<Transform>().position.x)
            {
                if (flipped)
                {
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftStartHash, false);
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, false);
                    if (GetComponent<Animator>().GetBool(HashIDs.cloudGradientLeftStartHash))
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, true);
                    }
                    else
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, false);
                    }
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightStartHash, true);
                }
                else
                {
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, false);
                    if (GetComponent<Animator>().GetBool(HashIDs.cloudGradientRightStartHash))
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, true);
                    } else
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, false);
                    }
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightStartHash, false);
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftStartHash, true);
                }
            }
            else
            {
                if (!flipped)
                {
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftStartHash, false);
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, false);
                    if (GetComponent<Animator>().GetBool(HashIDs.cloudGradientLeftStartHash))
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, true);
                    }
                    else
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, false);
                    }
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightStartHash, true);
                }
                else
                {
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, false);
                    if (GetComponent<Animator>().GetBool(HashIDs.cloudGradientRightStartHash))
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, true);
                    }
                    else
                    {
                        GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, false);
                    }
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightStartHash, false);
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftStartHash, true);
                }
            }
        }
        else
        {
            if (GetComponent<Animator>().GetBool(HashIDs.cloudGradientRightStartHash))
            {
                GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, true);
            }
            else if(GetComponent<Animator>().GetBool(HashIDs.cloudGradientLeftStartHash))
            {
                GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, true);
            }
            else
            {
                if (!GetComponent<Animator>().GetBool(HashIDs.cloudGradientRightEndHash))
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightEndHash, false);
                if (!GetComponent<Animator>().GetBool(HashIDs.cloudGradientLeftEndHash))
                    GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftEndHash, false);
            }
            GetComponent<Animator>().SetBool(HashIDs.cloudGradientRightStartHash, false);
            GetComponent<Animator>().SetBool(HashIDs.cloudGradientLeftStartHash, false);

        }

    }
}
