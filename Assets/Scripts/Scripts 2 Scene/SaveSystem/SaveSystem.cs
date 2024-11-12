using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    private string filePath;
    public ProgressData s_progressData;

    private void Awake()
    {
        // Define la ruta del archivo JSON donde se guardarán los datos
        filePath = Application.persistentDataPath + "/progress.json";
        
    }
    //private void Start()
    //{

    //    // Carga los datos de progreso al inicio del juego
    //    s_progressData = CargarProgreso();
    //    Debug.Log($"Nivel Actual: {s_progressData.actualLevel}, Tiempo Jugado: {s_progressData.timePlayed}, Puntuación: {s_progressData.totalPoints}");
    //}

    public void GuardarProgreso(ProgressData data) //Guarda los datos al darle a nextLv
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en " + filePath);
    }

    public ProgressData CargarProgreso()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ProgressData data = JsonUtility.FromJson<ProgressData>(json);
            Debug.Log("Datos cargados desde " + filePath);
            return data;
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo de progreso. Creando un nuevo progreso.");
            // Si no existe el archivo, devuelve un nuevo objeto ProgressData con valores por defecto
            return new ProgressData(1, 0, 0);
        }
        
    }
}
