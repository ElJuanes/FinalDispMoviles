using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int puntaje;
    bool inicioJuego = false;
    bool gana = false;

    void Update()
    {
        if (inicioJuego == false)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Play()
    {
        inicioJuego = true;
    }
    public void Punto()
    {
        puntaje++;
        UpdateScoreText();
        if (puntaje == 25 && gana == false)
        {
            
        }
    }
    private void UpdateScoreText()
    {
        score.text = puntaje.ToString();
    }
}
