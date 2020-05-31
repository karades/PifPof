using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;

    public void Start()
    {
        loseMenu.SetActive(false);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
