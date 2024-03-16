using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public float sensitivity = 1f; // Dönüþ hassasiyeti
    void Update()
    {
            // Fare giriþini al
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Nesnenin dönme deðerlerini güncelle
            transform.Rotate(Vector3.up, mouseX * sensitivity);
            transform.Rotate(Vector3.right, mouseY * sensitivity);
    }
}
