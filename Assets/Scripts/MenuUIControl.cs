using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIControl : MonoBehaviour {

    [SerializeField]
    GameObject aboutUsPanel;

    [SerializeField]
    Button StartGamePlayButton;

    [SerializeField]
    Button ShowAboutUsButton;

    

    void Start()
    {
        aboutUsPanel.SetActive(false);
        StartGamePlayButton.onClick.AddListener(StartGame);
        ShowAboutUsButton.onClick.AddListener(ShowAboutUs);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void ShowAboutUs()
    {
        aboutUsPanel.SetActive(true);
    }


    public void ClosePanel(string panelName)
    {
        if(panelName == "aboutUs")
        {
            aboutUsPanel.SetActive(false);
        }
    }
	
	
}
