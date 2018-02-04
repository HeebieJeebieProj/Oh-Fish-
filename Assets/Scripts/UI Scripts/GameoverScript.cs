﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameoverScript : MonoBehaviour {

    public GameObject Gameover;
    //public GameObject overlay;
    public Button endTrip;
    public static bool gameover = false;
    string check, checker;
    int baitsActive;
    HookManagerScript hookManagerScript;
    public GameObject hookSelectionView;
    public GameObject baitSelectionView;
    public GameObject startButton;
    public GameObject BaitSelection;

    public GameObject textViews;

    public Text timerText;
    public Button videoButton;
    public Button coinButton;

    public static bool replayActive;

    public GameObject Calculation;

    public int time = 5;
    private int variableTime;

    private bool gameOverStarted;

    public static bool calculationStart;

    private int blurFadeInHash = Animator.StringToHash("startBlurFadeIn");

	// Use this for initialization
	void Start () {
        variableTime = time;
        replayActive = false;
        endTrip.onClick.AddListener(EndTrip);
        videoButton.onClick.AddListener(ContinueTripVideo);
        coinButton.onClick.AddListener(ContinueTripCoins);
        timerText.text = time.ToString();
        gameover = false;
        Gameover.SetActive(false);
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();
        checker = "-1";
        gameOverStarted = false;
        calculationStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (hookManagerScript.isActiveAndEnabled && hookManagerScript.hasSetup)
        {
            int active = 0;
            baitsActive = hookManagerScript.hooksActive;
            for ( int m = 0; m < 5; m++)
            {
                if (hookManagerScript.hooks[m].activeSelf && hookManagerScript.hooks[m].GetComponent<FishSpawnScript>().isActiveAndEnabled)
                {
                    active++;
                }
            }

            switch (active)
            {
                case 1:
                    check = "1";
                    break;
                case 2:
                    check = "11";
                    break;
                case 3:
                    check = "111";
                    break;
                case 4:
                    check = "1111";
                    break;
                case 5:
                    check = "11111";
                    break;
                default:
                    check = "";
                    break;
            }

        }

        for (int i = 0; i < hookManagerScript.numberOfHooksActive && hookManagerScript.isActiveAndEnabled && hookManagerScript.hasSetup; i++)
        {
            if (hookManagerScript.hooks[i].activeSelf && hookManagerScript.hooks[i].GetComponent<FishSpawnScript>().isActiveAndEnabled && hookManagerScript.hooks[i].GetComponent<FishSpawnScript>().baitScript.initialCount <= 0)
            {
                checker = checker + "1";
            }
        }

        Debug.Log(check + " " + checker);

        if (checker == check && hookManagerScript.isActiveAndEnabled && hookManagerScript.hasSetup)
        {
            //BaitSelectionScript.hasStarted = false;
            gameover = true;
            replayActive = false;
        }

        checker = "";

        if (gameover && !gameOverStarted)
        {
            gameOverStarted = true;
            textViews.SetActive(false);
            hookManagerScript.enabled = false;
            hookManagerScript.hasSetup = false;
            GameObject.Find("Crab GameObject").GetComponent<CrabSpawnScript>().enabled = false;
            Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.cameraGameoverHash);
            Camera.main.GetComponent<BlurAnimationScript>().changeBlur(4);
            timerText.text = time.ToString();
            variableTime = time;
            StartCoroutine(timer());
        }

        if (variableTime <= 0 && !replayActive)
        {
            variableTime = time;
            EndTrip();
        }

	}

    IEnumerator timer()
    {
        yield return new WaitForSeconds(4f);

        variableTime = time;
        timerText.text = variableTime.ToString();

        while (variableTime != 0 && !replayActive)
        {
            variableTime--;
            timerText.text = variableTime.ToString();
            yield return new WaitForSeconds(1);
        }
        
    }

    void ContinueTripVideo()
    {
        replayActive = true;
        gameOverStarted = false;
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.calculationHash);
        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(0);
        GameObject.Find("Hooks").GetComponent<HookManagerScript>().enabled = true;
        gameover = false;
        int[] hookBaitNumber = { 0, 0, 10, 0, 0 };
        hookManagerScript.baitInitCount = hookBaitNumber;
        int[] baitOrder = { 0, 0, 0, 0, 0};

        GameObject.Find("Hooks").GetComponent<HookManagerScript>().baitOrder = baitOrder;
        GameObject.Find("Hooks").GetComponent<HookManagerScript>().numberOfHooksActive = 1;

        BaitSelectionScript.hasStarted = true;
        hookManagerScript.hasSetup = false;
        textViews.SetActive(true);
    }

    void ContinueTripCoins()
    {
        replayActive = true;
        gameOverStarted = false;
        Camera.main.GetComponent<Animator>().SetBool(HashIDs.cameraZoomOutHash, false);
        Camera.main.GetComponent<Animator>().SetBool(HashIDs.cameraZoomInHash, true);
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        gameover = false;
        Gameover.SetActive(false);
        int[] hookBaitNumber = { 0, 0, 10, 0, 0 };
        hookManagerScript.baitInitCount = hookBaitNumber;
        int[] baitOrder = { 0, 0, 0, 0, 0 };

        GameObject.Find("Hooks").GetComponent<HookManagerScript>().baitOrder = baitOrder;
        GameObject.Find("Hooks").GetComponent<HookManagerScript>().numberOfHooksActive = 1;

        BaitSelectionScript.hasStarted = true;
        textViews.SetActive(true);
    }

    void EndTrip()
    {
        gameover = false;
        gameOverStarted = false;
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.calculationHash);
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.calculationStartHash);
        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(5);
        calculationStart = true;
    }

}
