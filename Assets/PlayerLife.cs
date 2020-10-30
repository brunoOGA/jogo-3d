using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.gm.AtualizarHudVidas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida()
    {
        GameManager.gm.SetVidas(-1);
    }

    public void Reset()
    {
        if(GameManager.gm.GetVidas() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            GameManager.gm.SetGameOver();
            Cursor.visible = true;
            SceneManager.LoadScene(2);
            GameManager.gm.resetar();
        }
    }
}
