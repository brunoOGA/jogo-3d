using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptNPC : MonoBehaviour
{
    private NavMeshAgent agente;
    private GameObject pc;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        pc = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(pc.transform.position);
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<scriptPC>().GetSuperPoder())
            {
                this.gameObject.SetActive(false);
                GameObject controladorNPC = GameObject.Find("ControladorNPC");
                scriptControladorNPC script = controladorNPC.GetComponent<scriptControladorNPC>();
                script.respawn();

            }
            else
            {
                other.gameObject.GetComponent<PlayerLife>().PerdeVida();
                other.gameObject.GetComponent<PlayerLife>().Reset();
            }
        }


    }

}
