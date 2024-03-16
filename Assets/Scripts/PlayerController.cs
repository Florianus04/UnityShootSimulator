using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f; // Hareket hýzý

    void Update()
    {
        // Klavye giriþini al
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // Nesnenin transform x ve y deðerlerini güncelle
        Vector3 movement = new Vector3(xInput, yInput, 0f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

}
