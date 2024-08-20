using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CEnemyMove : MonoBehaviour
{
        private GameObject Building;
        void Start()
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = new Vector3(0,0.2f,0);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag == "MainBuilding")
            {
            Building = other.gameObject;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<NavMeshAgent>().velocity = new Vector3(0,0,0);
        }
        }

    private void Update()
    {
        if(Building == null)
        {
            
            Building = null;
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
        
    }
    public GameObject GetBuilding()
    {
        return Building;
    }


}
