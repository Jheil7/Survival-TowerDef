using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldEnemyAttack : MonoBehaviour
{
    Vector3 startPoint;
    Quaternion startRotation;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        startPoint=transform.position;
        startRotation=transform.rotation;
        navMeshAgent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetRotation();
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag=="Player"){
            navMeshAgent.destination=other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"){
            navMeshAgent.destination=startPoint;
        }
    }

    void ResetRotation(){
        float distanceToStart=Vector3.Distance(startPoint,transform.position);
        if(distanceToStart<=0.2f){
            transform.rotation=startRotation;
        }
    }

}
