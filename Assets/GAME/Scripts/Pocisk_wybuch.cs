using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk_wybuch : MonoBehaviour
{
    [SerializeField] GameObject wybuchPrefab;

    private void OnTriggerEnter(Collider inny)
    {
        if (inny.gameObject.CompareTag("Przeciwnik"))
        {
            Wybuch();
        }
    }

    void Wybuch()
    {
        Instantiate(wybuchPrefab, transform.position, Random.rotation);
        Destroy(gameObject);
    }
}
