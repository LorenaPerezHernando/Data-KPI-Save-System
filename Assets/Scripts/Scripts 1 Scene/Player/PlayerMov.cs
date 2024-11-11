using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMov : MonoBehaviour
{
    public bool GAMEON;

    private Rigidbody rb;
    public float speed = 4f;

    private void Awake()
    {
        GAMEON = true;
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {

    }

    void Update()
    {
        if(GAMEON == true)
        {

           float x = Input.GetAxis("Horizontal");
           float z = Input.GetAxis("Vertical");

           Vector3 move = transform.right * x + transform.forward * z;

           rb.MovePosition(rb.position + move * speed * Time.deltaTime);


        }
        

    }


}
