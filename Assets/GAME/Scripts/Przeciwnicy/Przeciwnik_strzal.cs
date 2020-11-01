using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik_strzal : MonoBehaviour
{
    [SerializeField] GameObject pociskPrefab;
    [SerializeField] AudioClip dzwiekStrzalu;
    [SerializeField] Transform miejsceStrzalu;

    [SerializeField] float predkoscPocisku;
    [SerializeField] float odstepStrzalow;
    [SerializeField] float czasZyciaPocisku;

    [SerializeField] bool czyNamierza;

    AudioSource odtwarzacz;
    Transform graczTransform;
    float godzinaNastepnegoStrzalu = 0;

    private void Start()
    {
        odtwarzacz = GetComponent<AudioSource>();
        graczTransform = FindObjectOfType<Gracz_ruch>().transform;
    }

    void Update()
    {
        if (Time.time >= godzinaNastepnegoStrzalu)
        {
            Strzel();
        }
    }

    void Strzel()
    {
        GameObject pocisk = Instantiate(pociskPrefab, miejsceStrzalu.position, Quaternion.LookRotation(transform.forward));

        Rigidbody rb = pocisk.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 kierunek = new Vector3();


            if (czyNamierza == true) 
            {
                kierunek = graczTransform.position - transform.position;
                kierunek = kierunek.normalized;

            }
            else { kierunek = transform.forward; }

            rb.AddForce(predkoscPocisku * kierunek, ForceMode.VelocityChange);
        }

        odtwarzacz.PlayOneShot(dzwiekStrzalu);
        Destroy(pocisk, czasZyciaPocisku);
        godzinaNastepnegoStrzalu = Time.time + odstepStrzalow;
    }
}
