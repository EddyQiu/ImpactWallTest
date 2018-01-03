using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float projectileStrength = 10.0f;

    [SerializeField]
    float lifeTime = 2.0f;

    [SerializeField]
    GameObject hitParticle;

    GameObject character;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Gun");
        rb = GetComponent<Rigidbody>();
        if (rb != null && character != null)
            rb.AddForce(character.transform.forward * projectileStrength);

        StartCoroutine(DestroyBullet());
	}

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }


    void OnCollisionEnter(Collision c)
    {
        if (rb != null)
            rb.useGravity = true;

        if (c.collider.tag == "Enemy")
        {   
            Instantiate(hitParticle, c.contacts[0].point, Quaternion.identity);
            Enemy enemy = c.gameObject.GetComponent<Enemy>();

            if (enemy != null)
                enemy.health -= 1;
            
            Destroy(this.gameObject);
             
        }
    }


}
