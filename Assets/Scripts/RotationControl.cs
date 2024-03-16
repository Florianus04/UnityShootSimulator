using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public float sensitivity = 1f; // D�n�� hassasiyeti
    void Update()
    {
            // Fare giri�ini al
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Nesnenin d�nme de�erlerini g�ncelle
            transform.Rotate(Vector3.up, mouseX * sensitivity);
            transform.Rotate(Vector3.right, mouseY * sensitivity);
    }
}
