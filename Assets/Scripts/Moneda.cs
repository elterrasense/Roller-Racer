using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    private BullInventari bullInventari;

    public AudioSource emisor;
    public AudioClip sonido;
    public float volumen = 1f;

    private void Start()
    {
        bullInventari = GameObject.FindGameObjectWithTag("Player").GetComponent<BullInventari>();
    }
    void Update()
    {

        //Rota la moneda una cantidad diferente en cada dirección y en cada intervalo de tiempo
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //emisor.PlayOneShot(sonido, volumen);
            AudioSource.PlayClipAtPoint(sonido, this.gameObject.transform.position);
            Destroy(gameObject);
            bullInventari.Cantidad += 1;
        }
    }
}