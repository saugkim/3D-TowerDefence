using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIControl : MonoBehaviour {

    [SerializeField]
    GameObject aboutUsPanel;


    void Start()
    {
        aboutUsPanel.SetActive(false);
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
