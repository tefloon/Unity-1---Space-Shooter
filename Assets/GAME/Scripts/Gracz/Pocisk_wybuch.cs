using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk_wybuch : MonoBehaviour
{
    [SerializeField] GameObject wybuchPrefab;
    [SerializeField] string tagCelu;
    [SerializeField] int obrazenia;

    private void OnTriggerEnter(Collider inny)
    {
        if (inny.gameObject.CompareTag(tagCelu))
        {
            Zycie zycieSkrypt = inny.GetComponent<Zycie>();
            if (zycieSkrypt != null)
            {
                zycieSkrypt.ZadajObrazenia(obrazenia);
            }


            Wybuch();
        }
    }

    void Wybuch()
    {
        Instantiate(wybuchPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
