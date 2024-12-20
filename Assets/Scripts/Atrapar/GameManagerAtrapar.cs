using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerAtrapar : MonoBehaviour
{
    public TextMeshProUGUI scoreAzul;
    public TextMeshProUGUI scoreRojo;
    private int PuntosAzul = 0;
    private int PuntosRojo = 0;
    public GameObject GanaRojo;
    public GameObject GanaAzul;
    bool gana = false;
    SpawnerPuntos spawnerPuntos;

    private void Start()
    {
        spawnerPuntos = GameObject.FindObjectOfType<SpawnerPuntos>();
    }
    public void inicio()
    {
        spawnerPuntos.isSpawning = true;
    }

    public void PuntoRojo()
    {
        PuntosRojo++;
        UpdateScoreText();
        if(PuntosRojo == 25 && gana == false)
        {
            gana = true;
            Time.timeScale = 0f;
            GanaRojo.SetActive(true);
        }
    }
    public void PuntoAzul()
    {
        PuntosAzul++;
        UpdateScoreText();
        if (PuntosAzul == 25 && gana == false)
        {
            gana = true;
            Time.timeScale = 0f;
            GanaAzul.SetActive(true);
        }
    }
    private void UpdateScoreText()
    {
        scoreAzul.text = PuntosAzul.ToString();
        scoreRojo.text = PuntosRojo.ToString();
    }
}
