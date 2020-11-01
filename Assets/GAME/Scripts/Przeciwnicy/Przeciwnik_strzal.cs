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

    AudioSource odtwarzacz;
    Transform graczTransform;
    float godzinaNastepnegoStrzalu = 0;

    private void Start()
    {
        odtwarzacz = GetComponent<AudioSource>();
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
            rb.AddForce(predkoscPocisku * transform.forward, ForceMode.VelocityChange);
        }

        odtwarzacz.PlayOneShot(dzwiekStrzalu);
        Destroy(pocisk, czasZyciaPocisku);
        godzinaNastepnegoStrzalu = Time.time + odstepStrzalow;
    }
}
