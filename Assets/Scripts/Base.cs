using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Base : MonoBehaviour
{

    [SerializeField]
    Vector3 offset;

    [HideInInspector]
    public TowerDatabase tempTower;

    [HideInInspector]
    public GameObject tower;

    [HideInInspector]
    public int upgradeState;

    int cost;
    bool isOccupied = false;


    private void Start()
    {
        upgradeState = 0;
        tower = null;
    }

    public void BuildTower(TowerDatabase towerToBuild)
    {

        if (GameManagement.currentGold < towerToBuild.cost)
        {
            BuildManager.instance.ShowMessage("Not enough gold to build tower", 2f);
            return;
        }

        GameManagement.currentGold -= towerToBuild.cost;
        GameObject towerObj = Instantiate(towerToBuild.towerPrefab, transform.position + offset, Quaternion.identity);

        tower = towerObj;

        tempTower = towerToBuild;
        isOccupied = true;
    }

    public int CheckUpgradePrice()
    {
        if (upgradeState == 0)
        {
            cost = tempTower.upgrade1Cost;
        }
        else if (upgradeState == 1)
        {
            cost = tempTower.upgrade2Cost;
        }
        else
        {
            cost = 0;
        }
        return cost;
    }

    public int CheckSellPrice()
    {
        if (upgradeState == 0)
        {
            cost = tempTower.cost / 5;
        }
        else if (upgradeState == 1)
        {
            cost = tempTower.upgrade1Cost / 5;
        }
        else if (upgradeState == 2)
        {
            cost = tempTower.upgrade2Cost / 5;
        }
        else
        {
            cost = 0;
        }
        return cost;
    }

    public void UpgradeTower()
    {
        if (upgradeState == 0)
        {
            if (GameManagement.currentGold < tempTower.upgrade1Cost)
            {
                BuildManager.instance.ShowMessage("Not enough gold to upgrade", 2f);
                return;
            }

            Destroy(tower.gameObject);

            GameManagement.currentGold -= tempTower.upgrade1Cost;
            GameObject towerObj = Instantiate(tempTower.towerUpgraded1Prefab, transform.position + offset, Quaternion.identity);
            tower = towerObj;
            upgradeState++;
            cost = tempTower.upgrade1Cost;
            BuildManager.instance.DeselectBase();
        }

        else if (upgradeState == 1)
        {
            if (GameManagement.currentGold < tempTower.upgrade2Cost)
            {
                BuildManager.instance.ShowMessage("Not enough gold", 2f);
                return;
            }

            Destroy(tower.gameObject);

            GameManagement.currentGold -= tempTower.upgrade2Cost;
            GameObject towerObj = Instantiate(tempTower.towerUpgraded2Prefab, transform.position + offset, Quaternion.identity);
            tower = towerObj;
            upgradeState++;
            cost = tempTower.upgrade2Cost;
            BuildManager.instance.DeselectBase();
        }

        else
        {
            BuildManager.instance.ShowMessage("Fully upgraded", 2f);
            BuildManager.instance.DeselectBase();
        }
    }


    public void ConfirmSellTower()
    {
        BuildManager.instance.ShowMessage("Are you sure, you want to sell?", 2f);
    }


    public void SellTower()
    {
        if (upgradeState == 0)
        {
            GameManagement.currentGold += tempTower.cost / 5;
        }
        else if (upgradeState == 1)
        {
            GameManagement.currentGold += tempTower.upgrade1Cost / 5;
        }
        else if (upgradeState == 2)
        {
            GameManagement.currentGold += tempTower.upgrade2Cost / 5;
        }
        else
        {
            return;
        }

        Destroy(tower);
        BuildManager.instance.DeselectBase();
        tower = null;
        isOccupied = false;
    }


    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(isOccupied)
        {
            BuildManager.instance.SelectBase(this);
            return;
        }

        if (!BuildManager.instance.isTowerSelected)
        {
            BuildManager.instance.ShowMessage("Select tower to build", 2f);
            return;
        }

        BuildTower(BuildManager.instance.towerToBuild);
    }
}