using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerLessPoints : MonoBehaviour
{
    GameOn managerGameOn;
    [SerializeField] AudioClip failClip;
    [SerializeField] AudioSource AudioSource;

    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BeachObject")
        {
            managerGameOn.points--;
            AudioSource.volume = 0.2f;
            AudioSource.PlayOneShot(failClip);
        }
    }
}
