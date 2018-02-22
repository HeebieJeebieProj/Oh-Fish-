using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationScript : MonoBehaviour {

    public GameObject comboTextGameObject;
    private int[] fishCounts;

    public GameObject[] content;
    public Text[] contentText;
    public Image[] contentImage;

    public Button home;
    public Button retry;

    public Sprite[] fishSprites;

    public GameObject BaitSelection;
    public GameObject hookSelectionView;
    public GameObject baitSelectionView;
    public GameObject startButton;

    public GameObject clouds;
    public GameObject backMountain;
    public GameObject islands;
    public GameObject frontRocks;
    public GameObject backRocks;


    // Use this for initialization
    void Start () {
        home.onClick.AddListener(HomeButtonClicked);
        retry.onClick.AddListener(RetryButtonClicked);
        fishCounts = comboTextGameObject.GetComponent<CountScript>().countFish;
        clouds.SetActive(false);
        backMountain.SetActive(false);
        islands.SetActive(false);
        frontRocks.SetActive(false);
        backRocks.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameoverScript.calculationStart)
        {
            GameoverScript.calculationStart = false;
            fishCounts = comboTextGameObject.GetComponent<CountScript>().countFish;
            for (int i = 0; i < fishCounts.Length; i++)
            {
                if (fishCounts[i] > 0)
                {
                    content[i % 5].SetActive(true);
                    contentText[i % 5].text = fishCounts[i].ToString();
                    contentImage[i % 5].sprite = fishSprites[i];
                }
                else
                {
                    content[i % 5].SetActive(false);
                }
            }
        }
	}

    void HomeButtonClicked()
    {
        Camera.main.GetComponent<Animator>().ResetTrigger(HashIDs.calculationHash);
        Camera.main.GetComponent<Animator>().ResetTrigger(HashIDs.calculationStartHash);
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.cameraSlideToGoalsFromGameplay);
        comboTextGameObject.GetComponent<CountScript>().countFish = new int[5] { 0, 0, 0, 0, 0 };
    }

    void RetryButtonClicked()
    {
        Camera.main.GetComponent<Animator>().ResetTrigger(HashIDs.calculationHash);
        Camera.main.GetComponent<Animator>().ResetTrigger(HashIDs.calculationStartHash);
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.cameraSlideToGameplay);
        comboTextGameObject.GetComponent<CountScript>().countFish = new int[5] { 0, 0, 0, 0, 0 };
    }
}
