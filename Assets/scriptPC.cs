using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class scriptPC : MonoBehaviour
{
    private Rigidbody rbd;
    public float velocidade = 5;
    public float velRot = 100;
    private Quaternion rotOriginal;
    private float rotMouseX = 0;
    private float rotTecladoX = 0;
    private float tempoSuperPoder = 0;
    private float tempoInicio;
    private Boolean superPoder = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody>();
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float moverFrente = Input.GetAxis("Vertical");
        float moverLado = Input.GetAxis("Horizontal");

        Vector3 vel = new Vector3(moverLado * velocidade, rbd.velocity.y, moverFrente * velocidade);

        rotMouseX += Input.GetAxis("Mouse X");

        rbd.velocity = transform.TransformDirection(vel);

        if (Input.GetKey(KeyCode.Q))
            rotTecladoX -= 1;
        else if(Input.GetKey(KeyCode.E))
            rotTecladoX += 1;

        Quaternion lado = Quaternion.AngleAxis(rotMouseX+rotTecladoX, Vector3.up);

        transform.localRotation = rotOriginal * lado;

        if (tempoSuperPoder > 0)
        {
            float t = (Time.time - tempoInicio)%60;
            GameObject.Find("txtTempo").GetComponent<Text>().text = "Super Poder:\n" + (tempoSuperPoder - t).ToString("f2") + "s";
            if(tempoSuperPoder - t <= 0)
            {
                tempoSuperPoder = 0;
                GameObject.Find("txtTempo").GetComponent<Text>().text = " ";
                SetSuperPoder(false);
            }
                
        }
            
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<PlayerPontos>().AtualizarPontos(1);
        }
        if (other.gameObject.CompareTag("Estrela"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.GetComponent<PlayerPontos>().AtualizarPontos(10);
            SetSuperPoder(true);
            tempoSuperPoder = 15;
            tempoInicio = Time.time;
        }

    }



    public void SetSuperPoder(Boolean poder)
    {
        superPoder = poder;
    }

    public Boolean GetSuperPoder()
    {
        return superPoder;
    }

}
