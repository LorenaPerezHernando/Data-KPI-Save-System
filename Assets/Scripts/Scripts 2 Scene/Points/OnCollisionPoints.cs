using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPoints : MonoBehaviour
{
    GameOn managerGameOn;

    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BeachObject")
        {
            managerGameOn.points++;
            Destroy(collision.gameObject);
        }
        
    }

}
