using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    GameOn managerGameOn;
    [SerializeField] int timeToWait = 1; 

    [SerializeField] GameObject[] prefabBeachObj;


    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
    }
    void Start()
    {
        StartCoroutine(InstantiateObject());
        Destroy(gameObject, 20f);
    }



    IEnumerator InstantiateObject()
    {
        while(managerGameOn.gameOn == true)
        {

            for (int i = 0; i < prefabBeachObj.Length; i++)
            {
                yield return new WaitForSeconds(timeToWait);
                Instantiate(prefabBeachObj[i], transform.position, Quaternion.identity);

                if (i > prefabBeachObj.Length - 1)
                    i = 0;
                
            }
        }


    }

    

}
