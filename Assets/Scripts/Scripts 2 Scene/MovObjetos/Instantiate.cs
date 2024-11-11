using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    GameOn managerGameOn;
    [SerializeField] float timeToWait = 0.2f; 

    [SerializeField] GameObject[] prefabBeachObj;


    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
    }
    private void Start()
    {
    }

    public IEnumerator InstantiateObject()
    {
        int i = 0;
        while(managerGameOn.gameOn == true)
        {
            yield return new WaitForSeconds(timeToWait);

            Instantiate(prefabBeachObj[i], transform.position, Quaternion.identity);;
            i++;

            if (i >= prefabBeachObj.Length)
                i = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            managerGameOn.points++;
        }
    }



}
