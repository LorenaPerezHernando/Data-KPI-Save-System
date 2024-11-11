using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveSystem : MonoBehaviour
{
    private string filePath;
    public ProgressData s_progressData;


    private void Start()
    {
        // Define la ruta del archivo JSON donde se guardarán los datos
        filePath = Application.persistentDataPath + "/progress.json";

        // Carga los datos de progreso al inicio del juego
        s_progressData = CargarProgreso();
        Debug.Log($"Nivel Actual: {s_progressData.actualLevel}, Tiempo Jugado: {s_progressData.timePlayed}, Puntuación: {s_progressData.totalPoints}");
    }

    public void GuardarProgreso(ProgressData data) //Guarda los datos al darle a nextLv
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        print(filePath);
    }

    public ProgressData CargarProgreso()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ProgressData>(json);
            print(filePath);
        }
        return new ProgressData();  // Si no hay archivo, devuelve datos nuevos.
    }
}
