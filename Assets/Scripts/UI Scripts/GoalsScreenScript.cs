using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalsScreenScript : MonoBehaviour {

    public Text coins;
    public Text diamonds;

    public Text[] goals;

    public Button menu;
    public Button shop;
    public Button main;
    public Button startTrip;

    public GameObject baitSelection;

	// Use this for initialization
	void Start () {
        startTrip.onClick.AddListener(StartTripButtonClicked);
        menu.onClick.AddListener(MenuButtonClicked);
        shop.onClick.AddListener(ShopButtonClicked);
        main.onClick.AddListener(MainButtonClicked);
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.x == -14.5f)
        {
            //gameObject.SetActive(true);
        }
	}

    void StartTripButtonClicked()
    {
        GetComponent<Animator>().SetBool(HashIDs.startFadeHash, true);
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.cameraSlideToGameplay);
        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(3);
        baitSelection.SetActive(true);
        gameObject.SetActive(false);
    }

    void MenuButtonClicked()
    {

    }

    void ShopButtonClicked()
    {

    }

    void MainButtonClicked()
    {
        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(2);
    }
}
