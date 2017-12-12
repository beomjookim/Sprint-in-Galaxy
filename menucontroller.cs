using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menucontroller : MonoBehaviour {

    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
    public Text txtBestScore;

    // Use this for initialization
    void Start () {
        SetSoundState();
        txtBestScore.text = PlayerPrefs.GetFloat("BestScore", 0).ToString("0.0");
		Screen.orientation = ScreenOrientation.Landscape;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("MIT&KAIST co-op project");
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0)== 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0 )
        {
            AudioListener.volume = 1;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            audioOffIcon.SetActive(true);
            audioOnIcon.SetActive(false);
        }
    }

}
