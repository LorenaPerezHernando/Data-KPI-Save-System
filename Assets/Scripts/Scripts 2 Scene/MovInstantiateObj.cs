using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovInstantiateObj : MonoBehaviour
{
    GameOn managerGameOn;
    public Vector3 posInicial;
    public Vector3 posFinal;
    public float speed;
    bool movingToFinal;
    private float t;

    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
    }
    private void Start()
    {
        transform.position = posInicial;
    }
    void Update()
    {
        if (managerGameOn)
        {
            t += Time.deltaTime / speed;

            if (movingToFinal)
            {
                transform.position = Vector3.Lerp(posInicial, posFinal, t);
                if (t >= 1f)
                {
                    t = 0f; 
                    movingToFinal = false; // Cambia la dirección
                }
            }
            else
            {
                transform.position = Vector3.Lerp(posFinal, posInicial, t);

                if (t >= 1f)
                {
                    t = 0f; 
                    movingToFinal = true; 
                }
            }
        }
    }
}


        
