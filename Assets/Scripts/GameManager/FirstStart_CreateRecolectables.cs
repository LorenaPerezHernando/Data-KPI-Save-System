using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FirstStart_CreateRecolectables : MonoBehaviour
{
    //Properties
    public Transform[] placesOfRecolectables;
    public GameObject[] prefabsToRecolect;

    //Fields
    DataKPI s_dataKPI;

    private void Awake()
    {
      s_dataKPI = FindFirstObjectByType<DataKPI>();
  
    }

    private void Start()
    {
        CreateRecolectable();
    }


    public void CreateRecolectable()
    {
        for(int i = 0; i < placesOfRecolectables.Length; i++)
        {       
           Instantiate(prefabsToRecolect[i], placesOfRecolectables[i].position, Quaternion.identity);

        }

    }


    
}
