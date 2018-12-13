using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIControl : MonoBehaviour
{

    [SerializeField]
    Text goldText;

    [SerializeField]
    Text livesText;

    [SerializeField]
    Text tower1BuildCost;

    [SerializeField]
    Text tower2BuildCost;

    [SerializeField]
    TowerDatabase tower1;
    [SerializeField]
    TowerDatabase tower2;

    [SerializeField]
    GameObject GamePausePanel;
    [SerializeField]
    Button restartButtonGO;
    [SerializeField]
    Button restartButtonP;
    [SerializeField]
    Button quitButtonGO;
    [SerializeField]
    Button quitButtonP;

    [SerializeField]
    Button menuButtonGO;
    [SerializeField]
    Button menuButtonP;

    [SerializeField]
    Button resumeButton;
    [SerializeField]
    Button pauseButton;

    [SerializeField]
    Button upgradeButton;
    [SerializeField]
    Button sellButton;


    Base towerBase;

    [SerializeField]
    GameObject upgradeControlPanel;

    int cost;

    void Start ()
    {
        
        tower1BuildCost.text = tower1.cost.ToString();
        tower2BuildCost.text = tower2.cost.ToString();

        GamePausePanel.SetActive(false);
        upgradeControlPanel.SetActive(false);

        restartButtonGO.onClick.AddListener(RestartGame);
        restartButtonP.onClick.AddListener(RestartGame);

        quitButtonGO.onClick.AddListener(QuitGame);
        quitButtonP.onClick.AddListener(QuitGame);

        menuButtonGO.onClick.AddListener(GoToMenuScene);
        menuButtonP.onClick.AddListener(GoToMenuScene);

        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);

        sellButton.onClick.AddListener(SellTower);
        upgradeButton.onClick.AddListener(UpgradeTower);
    }

    void Update ()
    {
        goldText.text = "GOLD: " + GameManagement.currentGold.ToString();
        livesText.text = GameManagement.lives.ToString() + " left";
	}

    public void ShowSellPrice()
    {
        cost = towerBase.CheckSellPrice();
        sellButton.transform.GetChild(1).GetComponent<Text>().text = cost.ToString();
    }

    public void ShowUpgradeCost()
    {
        cost = towerBase.CheckUpgradePrice();

        if(cost > 0)
        {
            upgradeButton.transform.GetChild(1).GetComponent<Text>().text = cost.ToString();
        }
        else
        {
            upgradeButton.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void ShowTowerUpgradePanel(Base _base)
    {
        upgradeControlPanel.SetActive(true);
        Vector3 offset = new Vector3(0, 10f, -1f);
        towerBase = _base;
        upgradeControlPanel.transform.position = towerBase.transform.position + offset;
        
        ShowSellPrice();
        ShowUpgradeCost();
    }

    public void CloseUpgradePanel()
    {
        upgradeControlPanel.SetActive(false);
    }

    public void UpgradeTower()
    {
        towerBase.UpgradeTower();
    }

    public void SellTower()
    {
        towerBase.SellTower();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        GamePausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        GamePausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
