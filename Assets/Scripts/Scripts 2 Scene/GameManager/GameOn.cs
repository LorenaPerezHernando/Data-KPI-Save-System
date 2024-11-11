using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   

    
public class GameOn : MonoBehaviour
{
    private List<int> levels = new List<int> { 1, 2, 3};

    public bool gameOn;
    public int points;
    Instantiate s_Instantiate;
    CountDown s_CountDown;
    LevelManager s_LevelManager;
    EstadoDelNivel estadoActual;

    private void Awake()
    {
        s_Instantiate = FindObjectOfType<Instantiate>();
        s_CountDown = GetComponent<CountDown>();
        s_LevelManager = GetComponent<LevelManager>();
    }

    private void Update()
    {
        if(s_CountDown.timeCountTo0 == true)
        {
            s_CountDown.timeCountTo0 = false;
            s_LevelManager.CompletarNivel();
        }
    }

    public void StartGame() //From the StartButton
    {
        gameOn = true;
        points = 0;
        estadoActual = EstadoDelNivel.Jugando;
        print("Estado: Jugando");
        s_CountDown.TimeCounter();
        s_Instantiate.StartCoroutine(s_Instantiate.InstantiateObject());

    }


}
