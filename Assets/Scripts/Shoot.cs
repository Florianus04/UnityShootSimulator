using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab; // F�rlat�lacak obje
    public GameObject tufek,duman,patlama;
    public Transform launchPoint; // F�rlatma noktas�
    public Transform target; // Hedef nokta
    public float launchSpeed = 10f; // F�rlatma h�z�
    public float tepmeKuvveti;

    public Text Magazine;

    AudioSource aSource;
    public AudioClip shoot, reload, magazineSound;

    public int magazineMax;
    int magazine = 14;
    int mermiSayac=1;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (mermiSayac == 1 && magazine > 0)
            {
                LaunchProjectile();
            }
            else if(mermiSayac==0 && magazine > 0)
            {
                aSource.PlayOneShot(reload, 1f);
                mermiSayac = 1;
            }
            else if(magazine<=0)
            {
                aSource.PlayOneShot(magazineSound, 1f);
                magazine = magazineMax;
            }
        }
        Cursor.visible = false;
        Magazine.text = "Mermi : "+magazine;
        print(mermiSayac);
    }

    void LaunchProjectile()
    {
        // F�rlatma noktas�ndan hedefe do�ru bir vekt�r hesapla
        Vector3 launchDirection = (target.position - launchPoint.position).normalized;
        mermiSayac -= 1;
        magazine -= 1;
        // Objeyi f�rlatma noktas�nda olu�tur
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Instantiate(duman, launchPoint.position, transform.rotation);

        // F�rlatma h�z�n� ve y�n�n� ayarla
        aSource.PlayOneShot(shoot, 1f);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = launchDirection * launchSpeed;
        Tepme();
    }
    void Tepme()
    {
        tufek.transform.Rotate (new Vector3(transform.rotation.x + tepmeKuvveti, transform.rotation.y, transform.rotation.z));
    }
}
