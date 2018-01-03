using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour {

    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(DestroyAfter());
	}

    IEnumerator DestroyAfter()
    {
        if (ps != null)
        {
            yield return new WaitForSeconds(ps.main.duration);
            Destroy(gameObject);

        }
        else
            Destroy(gameObject);

    }
}
