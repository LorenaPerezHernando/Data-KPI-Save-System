using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f; //60 seconds
    [SerializeField] TextMeshProUGUI t_timerText;
    [SerializeField] TextMeshProUGUI t_recolectables;

    [SerializeField] TextMeshProUGUI t_puntacionFinal;
    [SerializeField] TextMeshProUGUI t_mensaje;
    [SerializeField] GameObject panelFinal;

    DataKPI s_dataKPI;
    PlayerMov s_playerMov;


    private void Awake()
    {
        s_dataKPI = FindFirstObjectByType<DataKPI>();
        s_playerMov = FindFirstObjectByType<PlayerMov>();
        panelFinal.SetActive(false);
    }


    void Update()
    {
        t_recolectables.text = s_dataKPI.recolectados.ToString();

        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Timer(timeRemaining);
        }

        if (timeRemaining <= 0)
            TimeOver();
    }

   void Timer(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        t_timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    void TimeOver()
    {
        s_playerMov.GAMEON = false;
        panelFinal.SetActive(true);
        t_puntacionFinal.text = "Puntuacion Final: " + s_dataKPI.recolectados.ToString();

        if(s_dataKPI.recolectados <= 0 || s_dataKPI.recolectados <= 5)
        {
            t_mensaje.text = "No te rindas, puedes conseguir más puntos";
        }
        if(s_dataKPI.recolectados == 6 || s_dataKPI.recolectados <= 14)
        {
            t_mensaje.text = "Muy bien, sigue así";

        }
        if (s_dataKPI.recolectados >= 15)
            t_mensaje.text = "WOW! Estas hecho un un profesional"; 
        //Panel con Puntuaciones
    }
}
