using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class BaitSelectionScript : MonoBehaviour {

    public GameObject scrollRectHook;
    public GameObject scrollRectBait;
    public GameObject startButton;
    public GameoverScript gameOverScript;
    public GameObject[] baitOptions;
    public int[] batchSizes;
    public int selectedBait = -1;
    int previousSelectedBait = -1;
    public GameObject[] hookOptions;
    public int[] hookBaitNumber;
    public int selectedHook = -1;
    int previousSelectedHook = -1;
    public int[] previousSelection;
    public static bool hasStarted;
    public GameObject textViews;

    public int numberOfBaitsActive = 5;
    public int numberOfHooksActive = 3;
    public int numberOfFishesActive = 5;
    public int hooksActive;

    public Color colorPressed;
    public Color colorDisabled;
    public Color colorNormal;

    private bool buttonStartActive;

    int zoomInHash = Animator.StringToHash("startZoom");

    private HookManagerScript hookManagerScript;

    // Use this for initialization
    void Start () {
        hookManagerScript = GameObject.Find("Hooks").GetComponent<HookManagerScript>();
        hasStarted = false;
        buttonStartActive = false;
        startButton.GetComponent<Button>().onClick.AddListener(gameStarted);
        for (int i = 0; i < 5; i++)
        {
            baitOptions[i].GetComponentInChildren<Text>().text = "No. of baits: " + batchSizes[i].ToString();

            hookOptions[i].GetComponentInChildren<Text>().text = hookBaitNumber[i].ToString();

            if ( i >= numberOfBaitsActive )
            {
                baitOptions[i].GetComponent<Button>().interactable = false;
            }

            if (i >= numberOfHooksActive)
            {
                hookOptions[i].GetComponent<Button>().interactable = false;
            }
        }
        if (previousSelection[0] != -1)
        {
            selectedHook = 0;
            selectedBait = previousSelection[0];

            for (int j = 0; j < previousSelection.Length; j++)
            {
                hookOptions[j].GetComponentInChildren<Text>().text = batchSizes[previousSelection[j]].ToString();
            }
        } else
        {
            for (int j = 0; j < previousSelection.Length; j++)
            {
                previousSelection[j] = -1;
            }
        }

        if (selectedBait != -1 && selectedHook != -1)
        {
            ColorBlock cb = baitOptions[selectedBait].GetComponent<Button>().colors;
            cb.normalColor = colorPressed;
            baitOptions[selectedBait].GetComponent<Button>().colors = cb;

            cb = hookOptions[selectedHook].GetComponent<Button>().colors;
            cb.normalColor = colorPressed;
            hookOptions[selectedHook].GetComponent<Button>().colors = cb;
        }

        hookOptions[0].GetComponent<Button>().onClick.AddListener(delegate { hookClicked(0); });
        hookOptions[1].GetComponent<Button>().onClick.AddListener(delegate { hookClicked(1); });
        hookOptions[2].GetComponent<Button>().onClick.AddListener(delegate { hookClicked(2); });
        hookOptions[3].GetComponent<Button>().onClick.AddListener(delegate { hookClicked(3); });
        hookOptions[4].GetComponent<Button>().onClick.AddListener(delegate { hookClicked(4); });

        baitOptions[0].GetComponent<Button>().onClick.AddListener(delegate { baitClicked(0); });
        baitOptions[1].GetComponent<Button>().onClick.AddListener(delegate { baitClicked(1); });
        baitOptions[2].GetComponent<Button>().onClick.AddListener(delegate { baitClicked(2); });
        baitOptions[3].GetComponent<Button>().onClick.AddListener(delegate { baitClicked(3); });
        baitOptions[4].GetComponent<Button>().onClick.AddListener(delegate { baitClicked(4); });
    }
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.x == 0f && !hasStarted)
        {
            scrollRectHook.SetActive(true);
            scrollRectBait.SetActive(true);
            startButton.SetActive(true);
        }

        if (previousSelectedBait != -1)
        {
            ColorBlock cb = baitOptions[previousSelectedBait].GetComponent<Button>().colors;
            cb = baitOptions[previousSelectedBait].GetComponent<Button>().colors;
            cb.normalColor = colorNormal;
            baitOptions[previousSelectedBait].GetComponent<Button>().colors = cb;
        } 

        if (selectedBait != -1)
        {
            ColorBlock cb = baitOptions[selectedBait].GetComponent<Button>().colors;
            cb = baitOptions[selectedBait].GetComponent<Button>().colors;
            cb.normalColor = colorPressed;
            baitOptions[selectedBait].GetComponent<Button>().colors = cb;
        }

        if (previousSelectedHook != -1)
        {
            ColorBlock cb = hookOptions[selectedHook].GetComponent<Button>().colors;
            cb.normalColor = colorNormal;
            hookOptions[selectedHook].GetComponent<Button>().colors = cb;
        }

        if (selectedHook != -1)
        {
            ColorBlock cb1 = hookOptions[selectedHook].GetComponent<Button>().colors;
            cb1.normalColor = colorPressed;
            hookOptions[selectedHook].GetComponent<Button>().colors = cb1;
        }

        int f;

        for (f = 0; f < numberOfHooksActive; f++)
        {
            if (hookBaitNumber[f] > 0)
            {
                break;
            }
        }

        if (f >= numberOfHooksActive)
        {
            buttonStartActive = false;
        } else
        {
            buttonStartActive = true;
        }

        startButton.GetComponent<Button>().interactable = buttonStartActive;
        
    }

    void gameStarted ()
    {
        gameOverScript.enabled = false;
        Camera.main.GetComponent<Animator>().SetBool(zoomInHash, true);
        hookManagerScript.enabled = true;
        hookManagerScript.baitInitCount = hookBaitNumber;
        int[] baitOrder = new int[5];
        hooksActive = 0;
        for (int k = 0; k < 5; k++)
        {
            if (previousSelection[k] != -1)
            {
                hooksActive++;
                baitOrder[k] = previousSelection[k] + 1;
            }
        }

        hookManagerScript.baitOrder = baitOrder;
        hookManagerScript.numberOfHooksActive = numberOfHooksActive;
        hookManagerScript.hooksActive = hooksActive;
        hookManagerScript.numberOfFishesActive = numberOfFishesActive;

        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(0);

        hasStarted = true;
        //gameObject.SetActive(false);
        //textViews.SetActive(true);
    }

    void baitClicked (int i)
    {
        if (selectedHook != -1)
        {
            if (selectedBait != -1)
            {
                previousSelectedBait = selectedBait;
                ColorBlock cb = baitOptions[selectedBait].GetComponent<Button>().colors;
                cb = baitOptions[selectedBait].GetComponent<Button>().colors;
                cb.normalColor = colorNormal;
                baitOptions[selectedBait].GetComponent<Button>().colors = cb;
            }

            selectedBait = i;

            ColorBlock cb1 = baitOptions[selectedBait].GetComponent<Button>().colors;
            cb1.normalColor = colorPressed;
            baitOptions[selectedBait].GetComponent<Button>().colors = cb1;

            hookOptions[selectedHook].GetComponentInChildren<Text>().text = batchSizes[i].ToString();

            previousSelection[selectedHook] = i;
            hookBaitNumber[selectedHook] = batchSizes[i];
        }
    }

    void hookClicked (int i)
    {
        if (previousSelection[i] != 0 && previousSelection[i] != -1)
        {
            ColorBlock cb = hookOptions[selectedHook].GetComponent<Button>().colors;

            if (selectedHook != -1)
            {
                cb.normalColor = colorNormal;
                hookOptions[selectedHook].GetComponent<Button>().colors = cb;
            }

            selectedHook = i;

            baitClicked(previousSelection[i]);
        } else
        {
            if (selectedHook != -1)
            {
                previousSelectedHook = selectedHook;
                ColorBlock cb = hookOptions[selectedHook].GetComponent<Button>().colors;
                cb.normalColor = colorNormal;
                hookOptions[selectedHook].GetComponent<Button>().colors = cb;
            }

            selectedHook = i;
            ColorBlock cb1 = hookOptions[i].GetComponent<Button>().colors;
            cb1.normalColor = colorPressed;
            hookOptions[i].GetComponent<Button>().colors = cb1;
        }
    }
}
