using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovWater : MonoBehaviour
{
    public float velX, velY;
    Renderer render;


    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        render.material.SetTextureOffset("_MainTex", new Vector2(velX, velY) * Time.time);
    }
}
