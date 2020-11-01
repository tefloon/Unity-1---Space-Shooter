﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zycie : MonoBehaviour
{
    [SerializeField] GameObject efektSmierci;

    public int MaxHP;
    int ObecneHP;

    void Start()
    {
        ObecneHP = MaxHP;    
    }

    public void ZadajObrazenia(int obrazenia)
    {
        ObecneHP = ObecneHP - obrazenia;

        if (ObecneHP <= 0)
        {
            Smierc();
        }
    }

    void Smierc()
    {
        if (efektSmierci != null) Instantiate(efektSmierci, transform.position, Quaternion.identity);

        print("Zginąłem " + gameObject.name);
        Destroy(gameObject);
    }
}
