using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullController : MonoBehaviour
{
    public Moneda moneda;
    public Terrain terrain;
    
    // Start is called before the first frame update
    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Terrain").GetComponent<Terrain>();
        int minZ = (int) terrain.transform.position.z;
        int maxZ = (int) terrain.terrainData.size.z;
        int minY = (int) terrain.transform.position.y ;
        int maxY = (int) terrain.terrainData.size.y;

        for (int i = 0; i < 100; ++i){
            moneda = GameObject.FindGameObjectWithTag("Moneda").GetComponent<Moneda>();
            int randomH = Random.Range(minZ , maxZ);
            int randomV = Random.Range(minY, maxY);
            Instantiate(moneda, new Vector3(randomH, 2.0f, randomV), moneda.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
