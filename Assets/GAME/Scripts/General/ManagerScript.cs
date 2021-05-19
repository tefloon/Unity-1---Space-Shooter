using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI punktyTekst;
    [SerializeField] Text punktyTekst2;
    private int punkty;

    public void DodajPunkt()
    {
        punkty += 1;
        punktyTekst2.text = "Punkty: " + punkty.ToString();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("punkty", punkty);
        SceneManager.LoadScene("__GAME_OVER__");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("__MENU__");
        }
    }
}
