using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptControladorNPC : MonoBehaviour
{
    public GameObject NPC1;
    public GameObject NPC2;
    public float tempo;
    public Boolean aux;
    // Start is called before the first frame update
    void Start()
    {
       
        criarNPC(NPC1);
        criarNPC(NPC1);
        criarNPC(NPC2);
        criarNPC(NPC2);
    }

    public void criarNPC(GameObject npc)
    {
        Instantiate(npc, new Vector3(3, 2, 0), Quaternion.identity);
    }

    public IEnumerator criarNPC2()
    {
        yield return new WaitForSeconds(10);

        if (aux)
        {
            Instantiate(NPC1, new Vector3(3, 2, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(NPC2, new Vector3(3, 2, 0), Quaternion.identity);
        }
        aux = !aux;

    }

    public void respawn()
    {
        tempo += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo != 0)
        {
            StartCoroutine(criarNPC2());
            tempo-- ;

        }

    }

}
