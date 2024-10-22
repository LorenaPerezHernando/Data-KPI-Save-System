using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CreateRecolectables : MonoBehaviour
{
    //Properties
    [Range(0.3f, 3f)]
    public float offsetZ;
    public Transform[] placesOfRecolectables;
    public GameObject[] prefabsToRecolect;

    //Fields
    DataKPI s_dataKPI;
    bool startAgainCreating;
    int i = 0;
    int j = 0;

    private void Awake()
    {
      s_dataKPI = FindFirstObjectByType<DataKPI>();
        startAgainCreating = false;
  
    }

    private void Start()
    {
        i = 0; j = 0;
        CreateRecolectable();
    }

    void Update()
    {
        //if(s_dataKPI.recolectados == 6)
        //{
        //    RestartPos();
        //    CreateRecolectable();
        //}
    }



    public void CreateRecolectable()
    {
        for(i = 0; i < placesOfRecolectables.Length; i++)
        {       
           Instantiate(prefabsToRecolect[i], placesOfRecolectables[i].position, Quaternion.identity);

            //if (i > placesOfRecolectables.Length - 1)
            //    j = 0;

        }

    }

    public void RestartPos()
    {
        for(j = 0; j < placesOfRecolectables.Length; j++)
        {
            Vector3 currentPos = placesOfRecolectables[j].position;
            currentPos = new Vector3(placesOfRecolectables[j].position.x, placesOfRecolectables[j].position.y,
                placesOfRecolectables[j].position.z - offsetZ);
            placesOfRecolectables[j].position = currentPos;
           // i = 0;
        }

     }

    
}
