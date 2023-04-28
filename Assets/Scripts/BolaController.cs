using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    public float velocidad = 10f; // Define la velocidad base de la bola
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtenemos el RigidBody
    }

    void FixedUpdate()
    {
        // Obtenemos la dirección en la que esta mirando la camara
        Vector3 camMoveDirection = Camera.main.transform.forward;
        camMoveDirection.y = 0f; // Desactivar el movimiento vertical
        camMoveDirection = camMoveDirection.normalized;

        // Obtenemos las entradas del jugador 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Traduce los movimientos del jugador respecto al plano de la camara
        // y los convierte en vectores con la direccion de movimiento previamente
        // normalizada.
        Vector3 moveHorizontalCam = Camera.main.transform.right * moveHorizontal;
        Vector3 moveVerticalCam = camMoveDirection * moveVertical;
        Vector3 moveCam = (moveHorizontalCam + moveVerticalCam).normalized;

        // Aplica las fuerzas a la bola
        rb.AddForce(moveCam * velocidad);
    }
}
