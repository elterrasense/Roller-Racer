using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public float fuerzaDeSalto = 10f; // Fuerza base aplicada por JumpPads
    public float fuerzaDeImpulso = 20f; // Fuerza base aplicada por SpeedPads

    void OnTriggerEnter(Collider other) {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        // Comprobamos que tipo de collider ha encontrado la bola
        switch (other.gameObject.tag) {
            case "JumpPad":
                JumpPad(rb);
                break;
            case "SpeedPad":
                SpeedPad(rb);
                break;
        }
    }

    void JumpPad(Rigidbody rb) {
        if (rb != null) {
                // Aplicamos fuerza vertical a la bola
                rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            }
    }

    void SpeedPad(Rigidbody rb) {
        if (rb != null) {
            // Aplicamos un impulso en la direccion en la que se esta moviendo la bola
            Vector3 velocidadActual = rb.velocity.normalized;
            rb.AddForce(velocidadActual * fuerzaDeImpulso, ForceMode.Impulse);
        }
    }
}
