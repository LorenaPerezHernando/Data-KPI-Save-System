using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public enum KPIType
    {
        recolectable1KPI,
        recolectable2KPI,
        recolectable3KPI
    }
    //Properties
    public KPIType typeKPI;
    //Fields
    DataKPI s_dataKPI;
    CreateRecolectables s_createRecolectables;


    //Methods
    private void Awake()
    {
        s_createRecolectables = FindFirstObjectByType<CreateRecolectables>();
        s_dataKPI = FindObjectOfType<DataKPI>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
        if(collision.gameObject.tag == "Player")
        {
            print("Collision con Player");
            Destroy(gameObject);
            Recolectar();
           
            
        }
    }

    public void Recolectar()
    {
        s_dataKPI.IncrementarKPI(typeKPI);

        s_dataKPI.SendData(typeKPI);
    }


        
}
