using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HighScoreBoard : MonoBehaviour
{
    public Text oneTextValue;
    public Text twoTextValue;
    public Text threeTextValue;
    public Text fourTextValue;
    public Text fiveTextValue;
    public Text sixTextValue;
    public Text sevenTextValue;
    public Text eightTextValue;
    public Text nineTextValue;
    public Text tenTextValue;

    void Start()
    {
        oneTextValue.text = "1: " + PlayerPrefs.GetString("PlayerName", "") + ":    " + PlayerPrefs.GetInt("Score", 0);
    }

    public void ClearBoard()
    {
        oneTextValue.text = "1: ";
        twoTextValue.text = "2: ";
        threeTextValue.text = "3: ";
        fourTextValue.text = "4: ";
        fiveTextValue.text = "5: ";
        sixTextValue.text = "6: ";
        sevenTextValue.text = "7: ";
        eightTextValue.text = "8: ";
        nineTextValue.text = "9: ";
        tenTextValue.text = "10: ";
    }
}
