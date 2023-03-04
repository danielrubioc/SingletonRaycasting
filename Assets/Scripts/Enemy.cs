using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifeEnemy = 100f;
    public GameObject explosion;


    // Update is called once per frame
    void Update()
    {
        if(lifeEnemy <= 0)
        {
            GameObject explosionGO = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionGO, 1.2f);
            Destroy(this.gameObject);
        }
    }
}
