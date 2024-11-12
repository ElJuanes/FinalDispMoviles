using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool inicioJuego = false;
    void Start()
    {
    }

    // Update is called once per frame
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
}
