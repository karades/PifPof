using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI : MonoBehaviour
{

    TextMeshProUGUI Level;
    public GameObject LevelControl;
    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.Find("Level").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Level.text = "Level " + LevelControl.GetComponent<LevelControl>().getLevel();
    }
}
