using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadoDelNivel
{
    Inicio,
    Jugando,
    Finalizado
}
public class LevelManager : MonoBehaviour
{
    public List<EstadoDelNivel> estadoGame;
    public EstadoDelNivel estadoActual;
    public int actualLevel = 0;  // Índice de nivel
    private float tiempoJugado;
    private int puntuacionTotal;

    GameOn s_ManagerGameOn;
    UIControl s_UIControl;
    SaveSystem s_saveSystem;
    Instantiate s_instantiate;


    private void Awake()
    {
        s_ManagerGameOn = GetComponent<GameOn>();
        s_UIControl = FindAnyObjectByType<UIControl>();
        s_instantiate = FindAnyObjectByType<Instantiate>();
        s_saveSystem = GetComponent<SaveSystem>();

        ProgressData progress = s_saveSystem.CargarProgreso();
        actualLevel = progress.actualLevel;
        tiempoJugado = progress.timePlayed;
        puntuacionTotal = progress.totalPoints;

    }

    private void Update()
    {
        tiempoJugado += Time.deltaTime;
    }


    public void CompletarNivel()
    {
        estadoActual = EstadoDelNivel.Finalizado;
        print("Estado Finalizado");
        s_ManagerGameOn.gameOn = false;

        //Destruir los objetos en la escena
        string tagToDestroy = "BeachObject";

        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);  // Destruye el objeto
        }

        // Guardar 
        puntuacionTotal = puntuacionTotal + s_ManagerGameOn.points;
        ProgressData progress = new ProgressData
        {
            actualLevel = actualLevel + 1,
            timePlayed = tiempoJugado,
            totalPoints = puntuacionTotal
        };
        s_saveSystem.GuardarProgreso(progress);
        
        //Texto Panel
        s_UIControl.t_pointsPanelFinal.text = "Points: " + s_ManagerGameOn.points.ToString();
        s_UIControl.t_totalPoints.text = "Total Points: " + puntuacionTotal.ToString();
        s_UIControl.panelNextLevel.SetActive(true);

        //Poner nivel Mas dificil
        estadoActual = EstadoDelNivel.Inicio;
        actualLevel++;
        s_instantiate.timeToWait = s_instantiate.timeToWait + 0.01f;


    }



}
