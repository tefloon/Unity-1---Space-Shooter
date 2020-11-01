using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz_ruch : MonoBehaviour
{
    [SerializeField] float predkoscRuchu;
    [SerializeField] float ograniczenieGoraDol;
    [SerializeField] float ograniczeniePrawaLewa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ruch();
    }

    void Ruch()
    {
        Vector3 kierunek = Vector3.zero;

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
            && transform.position.x > -ograniczeniePrawaLewa )
        {
            kierunek += Vector3.left;
        }

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            && transform.position.x < ograniczeniePrawaLewa)
        {
            kierunek += Vector3.right;
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            && transform.position.z < ograniczenieGoraDol)
        {
            kierunek += Vector3.forward;
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
             && transform.position.z > -ograniczenieGoraDol)
        {
            kierunek += Vector3.back;
        }

        Vector3 przesuniecie = kierunek * predkoscRuchu * Time.deltaTime;

        transform.Translate(przesuniecie);
    }
}
