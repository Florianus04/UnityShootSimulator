using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Fýrlatýlacak obje
    public GameObject tufek,duman,patlama;
    public Transform launchPoint; // Fýrlatma noktasý
    public Transform target; // Hedef nokta
    public float launchSpeed = 10f; // Fýrlatma hýzý
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
        // Fýrlatma noktasýndan hedefe doðru bir vektör hesapla
        Vector3 launchDirection = (target.position - launchPoint.position).normalized;
        mermiSayac -= 1;
        magazine -= 1;
        // Objeyi fýrlatma noktasýnda oluþtur
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Instantiate(duman, launchPoint.position, transform.rotation);

        // Fýrlatma hýzýný ve yönünü ayarla
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
