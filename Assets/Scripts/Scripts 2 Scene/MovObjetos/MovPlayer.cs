using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovPlayer : MonoBehaviour
{
    #region Mov
    [Header("---Mov----")]
    public float speed = 2;
    public float speedYDash = 3;
    float speedInicial;
    GameOn managerGameOn;
    Rigidbody rb;
    #endregion
    [Header("---Audio---")]
    [SerializeField] AudioClip positiveClip;
    [SerializeField] AudioSource AudioSource;



    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        speedInicial = speed;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (managerGameOn == true)
        {

            float x = Input.GetAxis("Horizontal");

            Vector3 move = transform.right * x;

            rb.MovePosition(rb.position + move * speed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speedInicial = speed;
                speed = speed + speedYDash;
            }
            else
            {
                speed = speedInicial;
            }

            
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        print (collision.gameObject.tag);
        if(collision.gameObject.tag == "BeachObject")
        {
            print("Objeto golpeado");
            Destroy(collision.gameObject);


            AudioSource.PlayOneShot(positiveClip);
            print("Sonido Colision");


        }


    }

}

