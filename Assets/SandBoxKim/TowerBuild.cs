using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuild : MonoBehaviour
{
    public TowerDatabase tower1;
    public TowerDatabase tower2;

    [SerializeField]
    Button tower1BuildButton;
    [SerializeField]
    Button tower2BuildButton;


    void Start()
    {
        tower1BuildButton.onClick.AddListener(delegate { SelectTower(tower1); });
        tower2BuildButton.onClick.AddListener(delegate { SelectTower(tower2); });
    }


    public void SelectTower(TowerDatabase tower)
    {
        BuildManager.instance.SelectTowerToBuild(tower);
    }

    /*
    public void SelectTower1()
    {
        BuildManager.instance.SelectTowerToBuild(tower1);
    }

    public void SelectTower2()
    {
        BuildManager.instance.SelectTowerToBuild(tower2);
    }
    */
}
