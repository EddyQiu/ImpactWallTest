using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    NavMeshAgent agent;
    Transform goal;

	// Use this for initialization
	void Start () {
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
       
	}
}
