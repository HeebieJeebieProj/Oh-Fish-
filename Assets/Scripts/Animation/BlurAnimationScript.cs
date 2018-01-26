using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BlurAnimationScript : MonoBehaviour {

    public BlurOptimized blurOptimized;
    public float[] blurSize;
    public int[] downSample;
    public int screen;
    public float speed;

    private float frac;
    private int previousScreen;

	// Use this for initialization
	void Start () {
        screen = 1;
        frac = 1;
        previousScreen = 0;
	}
	
	// Update is called once per frame
	void Update () {

        frac += speed * 0.01f;
        frac = Mathf.Clamp(frac, 0, 1);
		
        switch(screen)
        {

            case 0: {


                    if (frac <= 0.5f)
                    {
                        blurOptimized.downsample = 1;
                    }
                    else
                    {
                        blurOptimized.downsample = 0;
                    }
                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                    if (blurOptimized.blurSize == 0)
                    {
                        blurOptimized.enabled = false;
                    }

                }
                break;

            case 1:
                {
                    blurOptimized.enabled = true;
                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);
                    
                }
                break;

            case 2:
                {
                    blurOptimized.enabled = true;
                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                }
                break;

            case 3:
                {
                    blurOptimized.enabled = true;
                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                }
                break;

            case 4:
                {
                    blurOptimized.enabled = true;
                    if (downSample[4] == 2)
                    {
                        if (frac <= 0.3f)
                        {
                            blurOptimized.downsample = 0;
                        }
                        else if (frac > 0.3f && frac <= 0.6f)
                        {
                            blurOptimized.downsample = 1;
                        }
                        else
                        {
                            blurOptimized.downsample = 2;
                        }
                    }
                    else
                    {
                        if (frac <= 0.5f)
                        {
                            blurOptimized.downsample = 0;
                        }
                        else
                        {
                            blurOptimized.downsample = 1;
                        }
                    }

                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                }
                break;

            case 5:
                {
                    blurOptimized.enabled = true;
                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                }
                break;

            case 6:
                {
                    blurOptimized.enabled = true;
                    if (downSample[6] == 2)
                    {
                        if (frac <= 0.3f)
                        {
                            blurOptimized.downsample = 0;
                        }
                        else if (frac > 0.3f && frac <= 0.6f)
                        {
                            blurOptimized.downsample = 1;
                        }
                        else
                        {
                            blurOptimized.downsample = 2;
                        }
                    }
                    else
                    {
                        if (frac <= 0.5f)
                        {
                            blurOptimized.downsample = 0;
                        }
                        else
                        {
                            blurOptimized.downsample = 1;
                        }
                    }

                    blurOptimized.blurSize = Mathf.Lerp(blurSize[previousScreen], blurSize[screen], frac);

                }
                break;
        }

	}

    public void changeBlur(int x)
    {
        frac = 0;
        previousScreen = screen;
        screen = x;
    }

}
