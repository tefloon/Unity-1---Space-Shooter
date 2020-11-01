using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zycie : MonoBehaviour
{
    [SerializeField] GameObject efektSmierci;

    public float MaxHP;
    protected float ObecneHP;

    protected virtual void Start()
    {
        ObecneHP = MaxHP;    
    }

    public virtual void ZadajObrazenia(int obrazenia)
    {
        ObecneHP = ObecneHP - obrazenia;

        if (ObecneHP <= 0)
        {
            Smierc();
        }
    }

    public virtual void Smierc()
    {
        if (efektSmierci != null) Instantiate(efektSmierci, transform.position, Quaternion.identity);
        FindObjectOfType<ManagerScript>().DodajPunkt();
        print("Zginąłem " + gameObject.name);
        Destroy(gameObject);
    }
}
