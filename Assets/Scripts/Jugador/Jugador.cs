using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador : MonoBehaviour
{
    public float velocidad = 2.0f;
    private Rigidbody rb;

    private Vector3 posicionInicial;

    public float velocidadMovimiento = 3f; 

    //Player Look Rotation 
    public float sensibilidadMouse = 50f;
    public Transform playerBody;
    public float xRotacion;
    public float yRotacion;

    // Start is called before the first frame update
    void Start()
    {
        // get playerBody 
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    void FixedUpdate()
    {
      
    }

    void Update()
    {
        MoverRigidBodyConCamara();
        RotacionCamara();
    }

    

    // move player with rigidbody and camera
    void MoverRigidBodyConCamara()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadMovimiento;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * velocidadMovimiento;

        Vector3 movimiento = new Vector3(x, 0, z);

        rb.AddForce(movimiento * velocidadMovimiento);

        // move player with camera
        transform.Translate(x, 0, z);
    } 
     
    // Rotate, zoom and move your camera player
    void RotacionCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);

        yRotacion += mouseX;
        yRotacion = Mathf.Clamp(yRotacion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0f);
    }

     
}
