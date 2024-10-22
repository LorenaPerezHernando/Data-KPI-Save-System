using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t_recolectables;
    DataKPI s_dataKPI;

    private void Awake()
    {
        s_dataKPI = FindFirstObjectByType<DataKPI>();
    }


    void Update()
    {
        t_recolectables.text = s_dataKPI.recolectados.ToString();
    }
}
