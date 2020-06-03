﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{

    TextMeshProUGUI level;
    TextMeshProUGUI currentWeapon;

    public GameObject LevelControl;
    public GameObject WeaponSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<TMPro.TextMeshProUGUI>();
        currentWeapon = GameObject.Find("Weapon").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level " + LevelControl.GetComponent<LevelControl>().getLevel();
        currentWeapon.text = WeaponSwitcher.GetComponent<WeaponSwitcher>().currentWeapon;

    }
}
