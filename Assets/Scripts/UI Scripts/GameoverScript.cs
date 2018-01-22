using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameoverScript : MonoBehaviour {

    public GameObject Gameover;
    public GameObject overlay;
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
        replayActive = false;
        endTrip.onClick.AddListener(EndTrip);
        videoButton.onClick.AddListener(ContinueTripVideo);
        coinButton.onClick.AddListener(ContinueTripCoins);
        timerText.text = time.ToString();
        gameover = false;
        Gameover.SetActive(false);
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();
        checker = "";
        gameOverStarted = false;
        calculationStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (hookManagerScript.isActiveAndEnabled)
        {
            int active = 0;
            baitsActive = hookManagerScript.numberOfHooksActive;
            for ( int m = 0; m < 5; m++)
            {
                if (hookManagerScript.hooks[m].activeSelf)
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

        for (int i = 0; i < baitsActive && hookManagerScript.isActiveAndEnabled; i++)
        {
            if (hookManagerScript.hooks[i].activeSelf && hookManagerScript.hooks[i].GetComponent<FishSpawnScript>().baitScript.initialCount <= 0)
            {
                checker = checker + "1";
            }
        }

        if (checker == check && /*BaitSelectionScript.hasStarted &&*/ hookManagerScript.isActiveAndEnabled)
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
            GameObject.Find("Crab GameObject").SetActive(false);
            //Camera.main.GetComponent<Animator>().SetBool(HashIDs.cameraZoomOutHash, true);
            Gameover.SetActive(true);
            //Camera.main.GetComponent<BlurOptimized>().enabled = true;
            timerText.text = time.ToString();
            variableTime = time;
            StartCoroutine(timer());
        }
	}

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);

        while (variableTime != 0 && !replayActive)
        {
            variableTime--;
            timerText.text = variableTime.ToString();
            yield return new WaitForSeconds(1);
        }

        EndTrip();
    }

    void ContinueTripVideo()
    {
        replayActive = true;
        gameOverStarted = false;
        Camera.main.GetComponent<Animator>().SetBool(HashIDs.cameraZoomOutHash, false);
        Camera.main.GetComponent<Animator>().SetBool(HashIDs.cameraZoomInHash, true);
        Camera.main.GetComponent<BlurOptimized>().enabled = false;
        gameover = false;
        Gameover.SetActive(false);
        int[] hookBaitNumber = { 0, 0, 10, 0, 0 };
        //hookManagerScript.numberOfBaits = hookBaitNumber;
        int[] baitOrder = { 0, 0, 11, 0, 0};

        //GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>().baitOrder = baitOrder;
        //GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>().numberHooks = 5;

        BaitSelectionScript.hasStarted = true;
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
        //hookManagerScript.numberOfBaits = hookBaitNumber;
        int[] baitOrder = { 0, 0, 11, 0, 0 };

        //GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>().baitOrder = baitOrder;
        //GameObject.Find("Hook Hanger").GetComponent<HookManagerScript>().numberHooks = 5;

        BaitSelectionScript.hasStarted = true;
        textViews.SetActive(true);
    }

    void EndTrip()
    {
        /*gameover = false;
        Gameover.SetActive(false);
        BaitSelection.SetActive(true);
        hookSelectionView.SetActive(true);
        baitSelectionView.SetActive(true);
        startButton.SetActive(true);*/

        gameover = false;
        gameOverStarted = false;
        Gameover.SetActive(false);
        Calculation.SetActive(true);
        calculationStart = true;
    }

}
