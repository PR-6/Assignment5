using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public Text pausedText;
	public GameObject playButton;
	public GameObject menuButton;
	public GameObject saveButton;
	public GameObject MusicToggle;
	public GameObject ExitButton;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	public void Reload()
	{
		pauseControl();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Next()
	{
		pauseControl();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void mainMenu()
	{
		pauseControl();
		SceneManager.LoadScene(0);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		pausedText.gameObject.SetActive(true);
		playButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);
		saveButton.gameObject.SetActive(true);
		MusicToggle.gameObject.SetActive(true);
		ExitButton.gameObject.SetActive(true);
	}

	public void hidePaused()
	{
		pausedText.gameObject.SetActive(false);
		playButton.gameObject.SetActive(false);
		menuButton.gameObject.SetActive(false);
		saveButton.gameObject.SetActive(false);
		MusicToggle.gameObject.SetActive(false);
		ExitButton.gameObject.SetActive(false);
	}

	public void saveGame()
	{
		PlayerPrefStore newSave = new PlayerPrefStore();
		newSave.Score = PlayerPrefs.GetInt("Score");
		newSave.PlayerName = PlayerPrefs.GetString("PlayerName");
		newSave.WordSpeed = PlayerPrefs.GetInt("WordSpeed");
		//newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic")==1?true:false;
		newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic");

		string json = JsonUtility.ToJson(newSave);
		Debug.Log(json);
		SaveIntoJson(json);
		mainMenu();
	}

	public void SaveIntoJson(string json)
	{
		System.IO.File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
	}
}
