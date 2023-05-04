using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    
    public GameObject bull;

    private TextMeshProUGUI textMesh;
    private BullInventari bullInventari;
    
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        bullInventari = bull.GetComponent<BullInventari>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.SetText(bullInventari.Cantidad.ToString());
    }
}
