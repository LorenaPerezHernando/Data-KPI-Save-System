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
    ProgressData s_progressData;


    private void Awake()
    {
        s_ManagerGameOn = GetComponent<GameOn>();
        s_UIControl = FindAnyObjectByType<UIControl>();
        s_instantiate = FindAnyObjectByType<Instantiate>();
        s_saveSystem = GetComponent<SaveSystem>();

        s_progressData = s_saveSystem.CargarProgreso();
        actualLevel = s_progressData.actualLevel;
        tiempoJugado = s_progressData.timePlayed;
        puntuacionTotal = s_progressData.totalPoints;

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

        
        //Texto Panel
        s_UIControl.t_pointsPanelFinal.text = "Points: " + s_ManagerGameOn.points.ToString();
        s_UIControl.t_totalPoints.text = "Total Points: " + puntuacionTotal.ToString();
        s_UIControl.panelNextLevel.SetActive(true);

        //Poner nivel Mas dificil
        estadoActual = EstadoDelNivel.Inicio;
        actualLevel++;
        s_instantiate.timeToWait = s_instantiate.timeToWait + 0.01f;

        ActualizarProgreso(actualLevel, tiempoJugado, puntuacionTotal);
        

    }

    public void ActualizarProgreso(int level, float timePlayed, int points)
    {
        print("Guardando Progreso");
        s_progressData = new ProgressData(level, timePlayed, points);
        s_saveSystem.GuardarProgreso(s_progressData);
        print("Fin Guardado");
    }



}
