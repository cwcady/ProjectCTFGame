using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Weapon : MonoBehaviour
{
    public float damage;
    public Camera camera;
    public float fireRate;

    private float nextFire;
    public Recoil Recoil_Script;
    public ParticleSystem muzzleFlash;
    public AudioSource weaponSoundSource;
    public int ammo = 30;
    public TextMeshProUGUI ammoText;

    public void Start()
    {
       weaponSoundSource.volume = 0.3f;
        ammoText.text = ammo + "/30";

    }

    void Update()
    {

        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }

        if(Input.GetButton("Fire1") && nextFire <= 0 && ammo > 0)
        {
            nextFire = 1 / fireRate;
            ammo--;
            ammoText.text = ammo + "/30";
            Fire(); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            ammoText.text = ammo + "/30";
        }
    }

    void Reload()
    {
        ammo = 30;
    }

    void AimDownSight()
    {


    }

    void Fire()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;
        Recoil_Script.RecoilFire();
        muzzleFlash.Play();
        weaponSoundSource.Play();

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {
            if(hit.transform.gameObject.GetComponent<Health>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
            }
        }
    }
}
