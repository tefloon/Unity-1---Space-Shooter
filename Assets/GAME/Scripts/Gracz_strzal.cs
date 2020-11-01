using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz_strzal : MonoBehaviour
{
    [SerializeField] GameObject pociskPrefab;
    [SerializeField] float predkoscPocisku;
    [SerializeField] float odstepStrzalow;
    [SerializeField] float czasZyciaPocisku;
    [SerializeField] Transform przechowalniaPociskow;

    float godzinaNastepnegoStrzalu = 0;


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= godzinaNastepnegoStrzalu)
        {
            Strzel();
        }
    }

    void Strzel()
    {
        GameObject pocisk = Instantiate(pociskPrefab, transform.position, 
                                        Quaternion.identity, przechowalniaPociskow);

        Rigidbody rb = pocisk.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(predkoscPocisku * Vector3.forward, ForceMode.VelocityChange);
        }

        Destroy(pocisk, czasZyciaPocisku);

        godzinaNastepnegoStrzalu = Time.time + odstepStrzalow;
    }
}
