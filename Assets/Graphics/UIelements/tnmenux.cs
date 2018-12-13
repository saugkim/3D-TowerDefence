using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tnmenux : MonoBehaviour {

	public GameObject AboutUs;

	public void PlayGame()
    {
	 	SceneManager.LoadSceneAsync("GameScene");
	}

    private void Start()
    {
        AboutUs.SetActive(false);
    }


    public void Credits ()
    {
		AboutUs.SetActive(true);

        if ( Input.GetKeyDown("return") || Input.GetKeyDown("space") )
		AboutUs.SetActive(false);
	}

	public void CloseCredits(){
		AboutUs.SetActive(false);
	}

	public void Exit(){
        Application.Quit();
	}
}


