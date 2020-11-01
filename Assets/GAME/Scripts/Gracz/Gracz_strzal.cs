using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz_strzal : MonoBehaviour
{
    [SerializeField] GameObject pociskPrefab;
    [SerializeField] AudioClip dzwiekStrzalu;
    [SerializeField] Transform miejsceStrzalu;

    [SerializeField] float predkoscPocisku;
    [SerializeField] float odstepStrzalow;
    [SerializeField] float czasZyciaPocisku;

    AudioSource odtwarzacz;
    float godzinaNastepnegoStrzalu = 0;

    private void Start()
    {
        odtwarzacz = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= godzinaNastepnegoStrzalu)
        {
            Strzel();
        }
    }

    void Strzel()
    {
        GameObject pocisk = Instantiate(pociskPrefab, miejsceStrzalu.position, Quaternion.identity);
        Rigidbody rb = pocisk.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(predkoscPocisku * Vector3.forward, ForceMode.VelocityChange);
        }

        odtwarzacz.PlayOneShot(dzwiekStrzalu);
        Destroy(pocisk, czasZyciaPocisku);
        godzinaNastepnegoStrzalu = Time.time + odstepStrzalow;
    }
}
