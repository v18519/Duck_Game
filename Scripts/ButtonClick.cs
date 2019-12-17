using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

    GameObject Option;
    Slider VolumeSlider;
    GameObject OptionImage;
    Button MusicOn;
    Button MusicOff;

    // Use this for initialization
    void Start () {
        Option = GameObject.FindGameObjectWithTag("Option");
        VolumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Slider>();
        OptionImage = GameObject.FindGameObjectWithTag("OptionImage");

        OptionImage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
            
	}

    public void OnLoginButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnOptionButtonClick()
    {
        OptionImage.SetActive(true);
    }
    
    public void OnBackButtonClick()
    {        
        OptionImage.SetActive(false);
    }

    public void OnLeaderBoardClick()
    {
        SceneManager.LoadScene("Score");
    }

    //public void OnMusicOffButtonClick()
    //{
      //  MusicOff.SetActive(false);
    //}
}
