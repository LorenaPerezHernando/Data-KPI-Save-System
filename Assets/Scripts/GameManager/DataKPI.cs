using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Recolectable;


public class DataKPI : MonoBehaviour
{

    [SerializeField] int s_kpiRecolect1;
    [SerializeField] int s_kpiRecolect2;
    [SerializeField] int s_kpiRecolect3;
    //Methods
    void Start()
    {
        s_kpiRecolect1 = 0;
        s_kpiRecolect2 = 0;
        s_kpiRecolect3 = 0;
    }
    public void IncrementarKPI(Recolectable.KPIType tipoKPI)
    {
        switch (tipoKPI)
        {
            case KPIType.recolectable1KPI:
                s_kpiRecolect1++;
                Debug.Log("Recolectable 1: " + s_kpiRecolect1);
                break;
            case KPIType.recolectable2KPI:
                s_kpiRecolect2++;
                Debug.Log("Recolectable 2: " + s_kpiRecolect2);
                break;
            case KPIType.recolectable3KPI:
                s_kpiRecolect3++;
                Debug.Log("Recolectable 3: " + s_kpiRecolect3);
                break;
        }
    }

    public void SendData(Recolectable.KPIType tipoKPI)
    {
        
        Debug.Log("Datos enviados" + tipoKPI);
    }
}
