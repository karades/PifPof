using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    TextMeshProUGUI level;
    TextMeshProUGUI currentWeapon;
    TextMeshProUGUI ammo;
    TextMeshProUGUI combo;

    public GameObject LevelControl;
    public GameObject WeaponSwitcher;
    public WeaponStats WeaponStats;
    Slider comboSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<TMPro.TextMeshProUGUI>();
        currentWeapon = GameObject.Find("Weapon").GetComponent<TMPro.TextMeshProUGUI>();
        ammo = GameObject.Find("Ammo").GetComponent<TMPro.TextMeshProUGUI>();
        combo = GameObject.Find("ComboText").GetComponent<TMPro.TextMeshProUGUI>();
        comboSlider = GameObject.Find("Combo").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level " + LevelControl.GetComponent<LevelControl>().getLevel();
        currentWeapon.text = WeaponSwitcher.GetComponent<WeaponSwitcher>().currentWeapon;
        ammo.text = "Ammo: " + WeaponStats.currentAmmo;
        combo.text = "Combo:" + LevelControl.GetComponent<LevelControl>().getCombo();
        comboSlider.value = LevelControl.GetComponent<LevelControl>().getComboTimer();

    }
}
