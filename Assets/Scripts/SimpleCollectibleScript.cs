using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour
{

    private Inventory ballInventory; // Instanciamos el inventario del jugador
    public GameObject ball;
    public bool rotate; // Si queremos que gire o no
    public float rotationSpeed;
    public AudioClip collectSound;
    public AudioSource emisor;
    public float volumen = 1f;
    public GameObject collectEffect;
    public TextMeshProUGUI scoreDisplay;

    void Start()
    {
        ballInventory = ball.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectSound, this.gameObject.transform.position);
            Destroy(gameObject);
            ballInventory.quantity += 1;
            scoreDisplay.SetText("Score: " + ballInventory.quantity);
            // Reproducir la animación de partículas collectEffect
            if (collectEffect != null)
            {
                GameObject collectEffectInstance = Instantiate(collectEffect, transform.position, Quaternion.identity);
                // Detener la reproducción después de un tiempo determinado
                StartCoroutine(StopCollectEffect(collectEffectInstance));
            }
        }
    }

    private IEnumerator StopCollectEffect(GameObject collectEffectInstance)
    {
        yield return new WaitForSeconds(1);
        collectEffectInstance.SetActive(false);
    }
}
