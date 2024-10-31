using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovObjects : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = Random.Range(0.5f, 4);
        
    }
    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
