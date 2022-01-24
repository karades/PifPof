using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComboUpgrade : MonoBehaviour
{
    [SerializeField]
    WeaponStats weaponStats;

    [SerializeField]
    LevelControl levelControl;

    int currentCombo = 1;

    Dictionary<int, int> upgradeListCheck = new Dictionary<int, int>();
    void Start()
    {
        if (!weaponStats)
        {
            weaponStats = GetComponent<WeaponStats>();
        }
        createUpgrades();

    }

    void createUpgrades()
    {
        upgradeListCheck.Add(1, 0);
        upgradeListCheck.Add(2, 0);
        upgradeListCheck.Add(3, 0);
        upgradeListCheck.Add(4, 0);
        upgradeListCheck.Add(5, 0);
    }
    void Update()
    {
        checkCombo();
        upgradeWeapons();
    }
    void checkCombo()
    {
        currentCombo = (int)levelControl.getCombo();
    }
    void upgradeWeapons()
    {

        switch (currentCombo)
        {
            case 1:
                if (upgradeListCheck[currentCombo] == 0)
                {
                    weaponStats.gunAmmo = 15;
                    weaponStats.maxGunAmmo = 15;
                    weaponStats.gunFiringSpeed = 1.0f;
                    upgradeListCheck[currentCombo] = 1;
                    weaponStats.gunUnlocked = true;
                }
                break;
            case 2:
                if (upgradeListCheck[currentCombo] == 0)
                {
                    weaponStats.gunAmmo = 30;
                    weaponStats.maxGunAmmo = 30;
                    weaponStats.gunFiringSpeed = 0.9f;
                    upgradeListCheck[currentCombo] = 1;
                }
                break;
            case 3:
                if (upgradeListCheck[currentCombo] == 0)
                {
                    weaponStats.machineGunUnlocked = true;
                    weaponStats.machineGunAmmo = 30;
                    weaponStats.maxMachineGunAmmo = 30;
                    weaponStats.machineGunFiringSpeed = 0.4f;
                    upgradeListCheck[currentCombo] = 1;
                }
                break;
            case 4:
                if (upgradeListCheck[currentCombo] == 0)
                {

                    upgradeListCheck[currentCombo] = 1;
                }
                break;
        }
    }
    
}


