using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 200f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem casquillo;
    public GameObject impactEffect;
    public GameObject impactEffectWall;
    public AudioSource gunShot;
    public AudioClip gunShotClip;
    public AudioClip gunShotHitClip;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        casquillo.Play();
        gunShot.PlayOneShot(gunShotClip);
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
          
           if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().lifeEnemy -= 10f;
                Debug.Log("Enemy");
                /* gunShot.PlayOneShot(gunShotHitClip); */  
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 3f);
            }

            if(hit.transform.tag ==  "Wall")
            {
                Debug.Log("Wall");
                gunShot.PlayOneShot(gunShotHitClip);
                GameObject impactGO = Instantiate( impactEffectWall, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 3f);

            }  
        }
    }
}
