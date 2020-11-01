using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PunktyScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI punktyTekst;

    private void OnEnable()
    {
        int punkty = PlayerPrefs.GetInt("punkty");
        punktyTekst.text = punkty.ToString();
    }
}
