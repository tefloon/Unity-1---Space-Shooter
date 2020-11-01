using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Ustawienia ogólne")]
    [SerializeField] GameObject przeciwnikPrefab; 
    [SerializeField] float ograniczenieX;

    [Header("Ustawienia trudności")]
    [SerializeField] float odstepMiedzyPrzeciwnikami;
    [SerializeField] float zmianaOstepu;
    [SerializeField] float predkoscPrzeciwnikow;
    [SerializeField] float zmianaPredkosci;  
    [SerializeField] int coIluPrzyspieszamy;

    float nastepnyPrzeciwnik;
    int licznikPrzeciwnikow;

    void StworzPrzeciwnika()
    {
        float miejsceX = Random.Range(-ograniczenieX, ograniczenieX);
        Vector3 miejsce = transform.position + new Vector3(miejsceX, 0, 0);

        var przeciwnik = Instantiate(przeciwnikPrefab, miejsce, Quaternion.LookRotation(transform.forward));
        przeciwnik.GetComponent<Przeciwnik_ruch>().predkosc = predkoscPrzeciwnikow;

        licznikPrzeciwnikow++;

        if (licznikPrzeciwnikow % coIluPrzyspieszamy == 0)
        {
            odstepMiedzyPrzeciwnikami *= zmianaOstepu;
            predkoscPrzeciwnikow *= zmianaPredkosci;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nastepnyPrzeciwnik)
        {
            StworzPrzeciwnika();
            nastepnyPrzeciwnik += odstepMiedzyPrzeciwnikami;
        }
    }
}
