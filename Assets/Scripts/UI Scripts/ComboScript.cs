using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour {

    public Text comboText;

    public static bool comboActive = false;
    public static int comboNumber = 0;

	// Use this for initialization
	void Start () {
        comboActive = false;
        comboNumber = 0;
	}

    public void showText(string s)
    {
        comboText.GetComponent<Text>().text = s;
        //GetComponent<Animator>().Play(HashIDs.comboTextFadeStateNameHash);
    }
}
