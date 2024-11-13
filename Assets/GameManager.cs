using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI levelText;
    private int puntaje;
    bool inicioJuego = false;
    bool gana = false;
    private int nivel = 1;
    public float fallSpeed = 2f;

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
        if (puntaje % 25 == 0)
        {
            CambiarNivel();
        }
    }
    private void CambiarNivel()
    {
        nivel++; 
        levelText.text = "Level "+ nivel;
        fallSpeed += 1.5f;
    }
    private void UpdateScoreText()
    {
        score.text = puntaje.ToString();
    }
}
