using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 5f);

    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        GezAyari.isabet += 1;

    }
}
