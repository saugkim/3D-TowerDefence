using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    [SerializeField]
    TowerDatabase tower1;
    [SerializeField]
    TowerDatabase tower2;

    [HideInInspector]
    public TowerDatabase towerToBuild;
 
    Base selectedBase;

    public GameUIControl gameUIControl;

    [HideInInspector]
    public bool isTowerSelected { get { return towerToBuild != null; } }
  
    [SerializeField]
    Text messageText;

    [SerializeField]
    Button tower1BuildButton;
    [SerializeField]
    Button tower2BuildButton;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    private void Start()
    {
        tower1BuildButton.onClick.AddListener(delegate { SelectTowerToBuild(tower1); });
        tower2BuildButton.onClick.AddListener(delegate { SelectTowerToBuild(tower2); });
    }

    public void ShowMessage(string message, float delay)
    {
        StartCoroutine(DisplayMessage(message, delay));
    }

    IEnumerator DisplayMessage(string message, float delay)
    {
        messageText.enabled = true;
        messageText.text = message;
        yield return new WaitForSeconds(delay);
        messageText.enabled = false;
    }


    public void SelectBase(Base _base)
    {
        if(selectedBase == _base)
        {
            DeselectBase();
            return;
        }
        selectedBase = _base;
        towerToBuild = null;

        gameUIControl.ShowTowerUpgradePanel(_base);
    }

    public void DeselectBase()
    {
        selectedBase = null;
        gameUIControl.CloseUpgradePanel();
    }
    
    public void SelectTowerToBuild(TowerDatabase tower)
    {
        towerToBuild = tower;
        DeselectBase();
    }
   
}
