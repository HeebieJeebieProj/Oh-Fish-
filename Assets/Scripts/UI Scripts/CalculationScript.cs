﻿using System.Collections;
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


    // Use this for initialization
    void Start () {
        home.onClick.AddListener(HomeButtonClicked);
        retry.onClick.AddListener(RetryButtonClicked);
        fishCounts = comboTextGameObject.GetComponent<CountScript>().countFish;
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
        gameObject.SetActive(false);
        comboTextGameObject.GetComponent<CountScript>().countFish = new int[5] { 0, 0, 0, 0, 0 };

    }

    void RetryButtonClicked()
    {
        gameObject.SetActive(false);
        BaitSelection.SetActive(true);
        hookSelectionView.SetActive(true);
        baitSelectionView.SetActive(true);
        startButton.SetActive(true);
        comboTextGameObject.GetComponent<CountScript>().countFish = new int[5] { 0, 0, 0, 0, 0 };
    }
}