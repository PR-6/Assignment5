using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GamePlayController : MonoBehaviour
{
    //PlayerName:
    public InputField playerName;

    //Slider for WordSpeed:
    public Slider sliderUI;
    private Text textSliderValue;

    //Play Music:
    public GameObject playMusicToggle;

    // Standard Functions:
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    // PlayerName Logic:
    public void setPlayerName()
    {
        Debug.Log(playerName.text);
        PlayerPrefs.SetString("PlayerName", playerName.text);
    }

    //Slider Speed logic:
    public void ShowSliderValue()
    {
        string sliderMessage = "Word Speed: " + sliderUI.value;
        textSliderValue.text = sliderMessage;
        PlayerPrefs.SetInt("WordSpeed", (int)sliderUI.value);
        Debug.Log("Word Speed Set to: " + sliderUI.value);
    }

    // Play Music
    public void SetPlayMusic()
    {
        Debug.Log(playMusicToggle.GetComponent<Toggle>().isOn);
        PlayerPrefs.SetInt("PlayMusic", playMusicToggle ? 1 : 0);
    }

    public void LoadGame()
    {
        string text = System.IO.File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        Debug.Log("Save Data: " + text);
        var json = JsonUtility.FromJson<PlayerPrefStore>(text);
        PlayerPrefs.SetInt("Score", json.Score);
        PlayerPrefs.SetString("PlayerName", json.PlayerName);
        PlayerPrefs.SetInt("WordSpeed", json.WordSpeed);
        PlayerPrefs.SetInt("PlayMusic", json.PlayMusic);
        PlayerPrefs.SetInt("one", json.one);
        PlayerPrefs.SetInt("two", json.two);
        PlayerPrefs.SetInt("three", json.three);
        PlayerPrefs.SetInt("four", json.four);
        PlayerPrefs.SetInt("five", json.five);
        PlayerPrefs.SetInt("six", json.six);
        PlayerPrefs.SetInt("seven", json.seven);
        PlayerPrefs.SetInt("eight", json.eight);
        PlayerPrefs.SetInt("nine", json.nine);
        PlayerPrefs.SetInt("ten", json.ten);
        PlayerPrefs.SetString("oneName", json.oneName);
        PlayerPrefs.SetString("twoName", json.twoName);
        PlayerPrefs.SetString("threeName", json.threeName);
        PlayerPrefs.SetString("fourName", json.fourName);
        PlayerPrefs.SetString("fiveName", json.fiveName);
        PlayerPrefs.SetString("sixName", json.sixName);
        PlayerPrefs.SetString("sevenName", json.sevenName);
        PlayerPrefs.SetString("eightName", json.eightName);
        PlayerPrefs.SetString("nineName", json.nineName);
        PlayerPrefs.SetString("tenName", json.tenName);
    }

    public int getCarSpeed()
    {
        return PlayerPrefs.GetInt("WordSpeed", 0);
    }
}
