using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPontos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameManager.gm.AtualizarHudPontos();
       GameManager.gm.AtualizarHudFase();
    }

    public void AtualizarPontos(int val)
    {
        GameManager.gm.SetPontos(val);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
