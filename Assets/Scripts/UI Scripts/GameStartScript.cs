using UnityEngine;
using UnityEngine.UI;


public class GameStartScript : MonoBehaviour {

    public Button startButton;
    public Text startButtonText;
    public Button settingsButton;
    public Text settingsButtonText;
    public Button contactButton;
    public Text contactButtonText;
    public GameObject goalsScreen;

	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(buttonFadeStart);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void buttonFadeStart()
    {
        GetComponent<Animator>().SetBool(HashIDs.startFadeHash, true);
        Camera.main.GetComponent<Animator>().SetTrigger(HashIDs.cameraSlideToGoalsFromMain);
        Camera.main.GetComponent<Animator>().Play(HashIDs.cameraStateHashSlideToGoalsFromMain, HashIDs.cameraLayerHash);
        Camera.main.GetComponent<BlurAnimationScript>().changeBlur(2);
        goalsScreen.SetActive(true);
    }
}
