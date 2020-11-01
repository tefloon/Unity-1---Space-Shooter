using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gracz_zycie : Zycie
{
    [SerializeField] RectTransform zyciePasek;
    [SerializeField] TextMeshProUGUI zycieTekst;
    public float maxDlugosc;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxDlugosc = zyciePasek.rect.width;
    }

    public override void ZadajObrazenia(int obrazenia)
    {
        base.ZadajObrazenia(obrazenia);
        UaktualnijZycie(ObecneHP / MaxHP);
    }


    public void UaktualnijZycie(float procent)
    {
        zycieTekst.text = (procent * 100).ToString();
        zyciePasek.sizeDelta = new Vector2(procent * maxDlugosc, 40);
    }

    public override void Smierc()
    {
        FindObjectOfType<ManagerScript>().GameOver();
    }
}
