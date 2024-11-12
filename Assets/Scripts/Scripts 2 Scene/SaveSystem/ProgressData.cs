using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ProgressData 
{
    public int actualLevel;
    public float timePlayed;
    public int totalPoints;

    public ProgressData(int actualLevel, float timePlayed, int totalPoints)
    {
        this.actualLevel = actualLevel;
        this.timePlayed = timePlayed;
        this.totalPoints = totalPoints;
    }
}
