using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GezAyari : MonoBehaviour
{
    float input;
    int kademe = 0,mesafe=50;
    public float gezAyari = 0.01f;

    public Text Mesafe,Isabet;

    public static int isabet = 0;

    private void Update()
    {
        Gez();
        Mesafe.text = "Gez Uzaklýk : " + mesafe;
        Isabet.text = "Ýsabet : " + isabet;
    }
    void Gez()
    {
        input = Input.GetAxis("Mouse ScrollWheel"); // Mouse tekerleði input deðeri

        if (input < 0 && kademe>0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - gezAyari, transform.position.z);
            kademe -= 1;
            mesafe -= 50;
        }
        if (input > 0 && kademe<6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + gezAyari, transform.position.z);
            kademe += 1;
            mesafe += 50;
        }
    }
    
}
