using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovPlayer : MonoBehaviour
{
    #region Mov
    public float speed = 2;
    public float speedYDash = 3;
    float speedInicial;
    GameOn managerGameOn;
    Rigidbody rb;
    #endregion

    #region MovGolpeado
    [SerializeField] bool objetoGolpeado;
    private bool rotationToFinal;
    public Quaternion rotationInicial; // Rotación inicial
    public Quaternion rotationFinal;   // Rotación final
    public float speedRotation = 2.0f; // Duración de la rotación
    private float t = 0f; // Factor de interpolación
    #endregion

    private void Awake()
    {
        managerGameOn = FindAnyObjectByType<GameOn>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        objetoGolpeado = false;
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

            //Rotacion por objeto golpeado
            if (objetoGolpeado == true)
            {
                t += Time.deltaTime / speedRotation;
                if(rotationToFinal)
                transform.rotation = Quaternion.Lerp(rotationInicial, rotationFinal, t);
                if (t >= 1f)
                {
                    t = 0f;
                    rotationToFinal = false;
                }               

            }
            else if( objetoGolpeado == true  && rotationToFinal == false) 
            {
                transform.rotation = Quaternion.Lerp(rotationFinal, rotationInicial, t);
                if(t >= 1f)
                {
                    t = 0f;
                    objetoGolpeado = false;
                }
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

            print("Sonido Colision");

            objetoGolpeado = true;

        }


    }

}

