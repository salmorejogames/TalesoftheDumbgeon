using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTileAtack : MonoBehaviour
{
    private static int NumFases = 3;
    public float faseTime = 0.5f;
    public SpellDmg spellDmg;
    [NonSerialized] public int actualFase;
    public GameObject[] fases = new GameObject[NumFases];
    public GameObject trigger;
    // Start is called before the first frame update
    void Awake()
    {
        fases[0].SetActive(true);
        trigger.SetActive(false);
        actualFase = 0;
        for (int i = 1; i < NumFases; i++)
        {
            fases[i].SetActive(false);
        }

        StartCoroutine(ChangeFase());
    }

    IEnumerator ChangeFase()
    {
        for (int i = 1; i < NumFases; i++)
        {
            yield return new WaitForSeconds(faseTime);
            fases[actualFase].SetActive(false);
            actualFase++;
            fases[actualFase].SetActive(true);
            if(actualFase == NumFases-1)
                trigger.SetActive(true);
        }
        yield return new WaitForSeconds(faseTime);
        Destroy(gameObject);
    }

    
}
