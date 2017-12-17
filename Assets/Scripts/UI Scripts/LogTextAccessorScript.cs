using UnityEngine;
using UnityEngine.UI;

public class LogTextAccessorScript : MonoBehaviour {

    public Text ComboText;

    private void Update()
    {
        if (ComboText.GetComponent<Text>().color.a == 0.0)
        {
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, 275f, GetComponent<RectTransform>().position.z);
        } else
        {
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, 251f, GetComponent<RectTransform>().position.z);
        }
    }

    public void showText(string s)
    {
        GetComponent<Text>().text = s;
        GetComponent<Animator>().Play(HashIDs.logTextFadeStateNameHash);
    }

}
