using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    Transform goal;

    public float health;

	// Use this for initialization
	void Start () {
        health = 10.0f;

        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Walk", 1.0f, 2.0f);      
    }

    void Walk()
    {
        if (agent != null)
        {
            goal = GameObject.Find("Player").transform;

            agent.destination = goal.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(gameObject);
	}


}
