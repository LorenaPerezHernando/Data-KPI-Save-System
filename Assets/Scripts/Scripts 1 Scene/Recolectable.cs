using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Recolectable : MonoBehaviour
{
    public enum KPIType
    {
        recolectable1KPI,
        recolectable2KPI,
        recolectable3KPI
    }
    #region Properties
    public KPIType typeKPI;
    public int timeWaitingToReset;
    #endregion
    #region Fields
    private DataKPI s_dataKPI;
    private FirstStart_CreateRecolectables s_createRecolectables;

    [SerializeField] private Renderer[] thisRenderer;
    [SerializeField] private Collider[] thisCollider;

    [SerializeField] private AudioSource thisAudioSource;
    #endregion

    #region Unity CallBacks
    private void Awake()
    {
        thisAudioSource = GetComponent<AudioSource>();
        thisRenderer = GetComponentsInChildren<Renderer>();
        thisCollider = GetComponentsInChildren<Collider>();

        s_createRecolectables = FindFirstObjectByType<FirstStart_CreateRecolectables>();
        s_dataKPI = FindObjectOfType<DataKPI>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
        if(collision.gameObject.tag == "Player")
        {
            print("Collision con Player");
            thisAudioSource.Play();
            DesactivarObjeto();
            Recolectar();                     
        }
    }
    #endregion

    public void Recolectar()
    {
        s_dataKPI.IncrementarKPI(typeKPI);

        s_dataKPI.SendData(typeKPI);
    }

    private void DesactivarObjeto()
    {
        print("Desactivar Objeto");
        foreach(Collider collider in thisCollider)
        {
            collider.enabled = false;
        }

        foreach(Renderer renderer in thisRenderer)
        {
            renderer.enabled = false;
        }
       

        StartCoroutine(ActivarObjeto());
    }
    IEnumerator ActivarObjeto()
    {
        print("Activar Objeto");
        yield return new WaitForSeconds(timeWaitingToReset);
        foreach (Collider collider in thisCollider)
        {
            collider.enabled = true;
        }

        foreach (Renderer renderer in thisRenderer)
        {
            renderer.enabled = true; 
        }

    }




}
