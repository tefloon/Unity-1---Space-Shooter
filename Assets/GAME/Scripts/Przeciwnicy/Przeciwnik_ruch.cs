using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik_ruch : MonoBehaviour
{
    public float predkosc;

    void Update()
    {
        Vector3 przesuniecie = Vector3.forward * predkosc * Time.deltaTime;
        transform.Translate(przesuniecie);

        if (transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
}
