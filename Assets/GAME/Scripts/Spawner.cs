using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject przeciwnikPrefab;
    [SerializeField] float odstepPomiedzyPrzeciwnikami;
    [SerializeField] float ograniczenieX;

    [SerializeField] float wspolczynnikPrzyspieszenia;
    [SerializeField] int coIluPrzyspieszamy;

    float nastepnyPrzeciwnik;
    int iluPrzeciwnikowBylo;

    void StworzPrzeciwnika()
    {
        float miejsceX = Random.Range(-ograniczenieX, ograniczenieX);
        Vector3 miejsce = transform.position + new Vector3(miejsceX, 0, 0);

        Instantiate(przeciwnikPrefab, miejsce, Quaternion.LookRotation(transform.forward));
        iluPrzeciwnikowBylo++;

        if (iluPrzeciwnikowBylo % coIluPrzyspieszamy == 0)
        {
            odstepPomiedzyPrzeciwnikami *= wspolczynnikPrzyspieszenia;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nastepnyPrzeciwnik)
        {
            StworzPrzeciwnika();
            nastepnyPrzeciwnik += odstepPomiedzyPrzeciwnikami;
        }
    }
}
