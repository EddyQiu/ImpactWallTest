using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float projectileStrength = 10.0f;

    [SerializeField]
    float lifeTime = 2.0f;

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
            Debug.Log("hit");
            Destroy(this.gameObject);
             
        }
    }


}
