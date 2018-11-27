using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    [SerializeField]
    string loadScene;

    [SerializeField]
    float waitingTimeToLoadMainScene;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitingTimeToLoadMainScene);
        SceneManager.LoadScene(loadScene);
    }
}