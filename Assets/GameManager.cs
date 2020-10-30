using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private int vidas = 3;
    private int placar = 0;
    private int fase = 1;
    private int goPlacar = 0;
    private int goFase = 1;
    private int auxPlacar = 0;
    void Awake()
    {
        
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        AtualizarHudVidas();
    }

    void Update()
    {  
        if(GameObject.Find("txtPlacarGameOver") != null)
        {
            GameObject.Find("txtPlacarGameOver").GetComponent<Text>().text = "GAME OVER \n Fase: " + goFase.ToString() + " Pontos: " + goPlacar.ToString();
        }
    }

    public void SetGameOver()
    {
        goPlacar = placar;
        goFase = fase;
    }
    public void SetVidas(int vida)
    {
        vidas += vida;
        auxPlacar = placar;
        AtualizarHudVidas();
    }

    public void resetar()
    {
        this.fase = 1;
        this.placar = 0;
        this.vidas = 3;
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetPontos(int ponto)
    {
        placar += ponto;
        AtualizarHudPontos();
        if(placar == 61 + auxPlacar)
        {
            fase++;
            auxPlacar = placar;
            AtualizarHudFase();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int GetPontos()
    {
        return placar;
    }

    public void AtualizarHudVidas()
    {
        GameObject.Find("txtVidas").GetComponent<Text>().text = "Vidas: " + vidas.ToString();
    }

    public void AtualizarHudPontos()
    {
        GameObject.Find("txtPlacar").GetComponent<Text>().text = "Pontos: " + placar.ToString();
    }

    public void AtualizarHudFase()
    {
        GameObject.Find("txtFase").GetComponent<Text>().text = "Fase: " + fase.ToString();
    }
}
