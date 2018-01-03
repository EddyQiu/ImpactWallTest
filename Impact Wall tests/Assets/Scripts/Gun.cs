using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]
    GameObject Bullet_GO;

    [SerializeField]
    Transform Muzzle_GO;

    [SerializeField]
    float fireRate = 0.05f;

    float lastShotTime;

	// Use this for initialization
	void Start () {
        lastShotTime = Time.time;
        Muzzle_GO = transform.Find("Muzzle");
	}

    void Update() 
    {
        if (Input.GetAxisRaw("Fire1") != 0 && Time.time > lastShotTime + fireRate && !Menu.isMenuOpen)
        {
            lastShotTime = Time.time;
            Instantiate(Bullet_GO, Muzzle_GO.position, Quaternion.identity);
        }

    }
}
