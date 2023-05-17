using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallController : MonoBehaviour
{
    public float pushForce = 10f; // Fuerza de empuje aplicada al jugador
    public float speed = 10f;
    public float minDistance = 5f;

    private Transform player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
    }

    void FixedUpdate()
    {
        // Calcula la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Si la distancia es menor que la distancia mínima, persigue al jugador
        if (distanceToPlayer < minDistance)
        {
            // Calcula la dirección hacia el jugador
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // Mueve la bola enemiga hacia el jugador
            rb.AddForce(directionToPlayer * speed);
        }
    }

    // Detecta si el jugador entra en contacto con la bola enemiga
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PushBall(other.gameObject);
        }
    }

    // Empuja al jugador
    private void PushBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Vector3 direccion = ball.transform.position - transform.position;
        direccion.y = 0.5f;
        direccion.Normalize();
        rb.AddForce(direccion * pushForce, ForceMode.Impulse);
    }
}
