using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private float bulletSpeed = 600;

    public Text textAmmo;
    private int ammoTotal;

    public float delay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        ammoTotal = 35;
        setTextoAmmo();

    }

    // Update is called once per frame
    void Update()
    {
        if(_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }

        if(Input.GetKeyDown(KeyCode.F))
           SceneManager.LoadScene("WinningScreen");;
    }

    void Shoot()
    {
        //Debug.Log("Shoot!");
        ammoTotal--;
        setTextoAmmo();
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 0.8f);
    }

    void setTextoAmmo()
    {
        textAmmo.text = " " + ammoTotal.ToString();
        if(ammoTotal == 0)
            StartCoroutine(LoadDelay());
        
    }

    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("OutOfAmmoScene");
    }
}
