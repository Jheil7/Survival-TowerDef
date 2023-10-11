using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class MoveToEnd : MonoBehaviour
{
    private NavMeshSurface surface;
    NavMeshAgent navMeshAgent;
    //Rigidbody myRb;
    Endpoint endpoint;
    Vector3 endpointPos;
    
    void Awake()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        endpoint=FindObjectOfType<Endpoint>();
        endpointPos=endpoint.transform.position;
        MoveTo(endpointPos);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEndpoint= Vector3.Distance(transform.position, endpointPos);
        if(distanceToEndpoint<3){
            navMeshAgent.isStopped=true;
        }
    }

    public void MoveTo(Vector3 destination){
        navMeshAgent.destination=destination;
        //navMeshAgent.isStopped=false;
    }

}
