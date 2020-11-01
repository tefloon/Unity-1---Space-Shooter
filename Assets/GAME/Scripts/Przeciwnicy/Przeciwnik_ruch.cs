using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik_ruch : MonoBehaviour
{
    public float predkosc;

    private void OnTriggerEnter(Collider inny)
    {
        print("Wpadam?");

        if (inny.gameObject.CompareTag("Gracz"))
        {
            Zycie zycieSkrypt = inny.GetComponent<Zycie>();
            if (zycieSkrypt != null)
            {
                zycieSkrypt.ZadajObrazenia(50);
            }

            GetComponent<Zycie>().ZadajObrazenia(9999);

            print("Wpadłem w gracza!");
        }
    }

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
