using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFrequencyManagerScript : MonoBehaviour {

    public static int[] active;

    public int maxFishesDay;
    public int maxFishesNight;

    private int maxFishesDayVariable;
    private int maxFishesNightVariable;

    private int numberOfActive;
    private HookManagerScript hookManagerScript;

    // Use this for initialization
    void Start () {

        active = new int[5];
        numberOfActive = 0;
        for (int i = 0; i < 5; i++)
        {
            active[i] = 0;
        }
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();

	}
	
	// Update is called once per frame
	void Update () {

        if (maxFishesDay == 4)
        {

            if (TimeManagerScript.timeOfDay >= 0 && TimeManagerScript.timeOfDay < 14400)
            {
                maxFishesDayVariable = 0;
            }
            else if (TimeManagerScript.timeOfDay >= 14400 && TimeManagerScript.timeOfDay <= 21600)
            {
                maxFishesDayVariable = 1;
            }
            else if (TimeManagerScript.timeOfDay > 21600 && TimeManagerScript.timeOfDay <= 32400)
            {
                maxFishesDayVariable = 2;
            }
            else if (TimeManagerScript.timeOfDay > 32400 && TimeManagerScript.timeOfDay <= 39600)
            {
                maxFishesDayVariable = 3;
            }
            else if (TimeManagerScript.timeOfDay > 39600 && TimeManagerScript.timeOfDay <= 46800)
            {
                maxFishesDayVariable = 4;
            }
            else if (TimeManagerScript.timeOfDay > 46800 && TimeManagerScript.timeOfDay <= 54000)
            {
                maxFishesDayVariable = 3;
            }
            else if (TimeManagerScript.timeOfDay > 54000 && TimeManagerScript.timeOfDay <= 61200)
            {
                maxFishesDayVariable = 2;
            }
            else if (TimeManagerScript.timeOfDay > 61200 && TimeManagerScript.timeOfDay <= 68400)
            {
                maxFishesDayVariable = 1;
            }
            else if (TimeManagerScript.timeOfDay > 68400 && TimeManagerScript.timeOfDay <= 86400)
            {
                maxFishesDayVariable = 0;
            }

        }
        else if (maxFishesDay == 3)
        {

            if (TimeManagerScript.timeOfDay >= 0 && TimeManagerScript.timeOfDay < 18000)
            {
                maxFishesDayVariable = 0;
            }
            else if (TimeManagerScript.timeOfDay >= 18000 && TimeManagerScript.timeOfDay <= 28800)
            {
                maxFishesDayVariable = 1;
            }
            else if (TimeManagerScript.timeOfDay > 28800 && TimeManagerScript.timeOfDay <= 39600)
            {
                maxFishesDayVariable = 2;
            }
            else if (TimeManagerScript.timeOfDay > 39600 && TimeManagerScript.timeOfDay <= 46800)
            {
                maxFishesDayVariable = 3;
            }
            else if (TimeManagerScript.timeOfDay > 46800 && TimeManagerScript.timeOfDay <= 57600)
            {
                maxFishesDayVariable = 4;
            }
            else if (TimeManagerScript.timeOfDay > 57600 && TimeManagerScript.timeOfDay <= 68400)
            {
                maxFishesDayVariable = 3;
            }
            else if (TimeManagerScript.timeOfDay > 68400 && TimeManagerScript.timeOfDay <= 86400)
            {
                maxFishesDayVariable = 0;
            }

        }

        FishCountScript.maxFishesDay = maxFishesDayVariable;

        numberOfActive = 0;

        for (int i = 0; i < hookManagerScript.numberOfHooksActive; i++)
        {

            numberOfActive += active[i];

        }

        if (numberOfActive < maxFishesDayVariable)
        {



        }

    }
}
