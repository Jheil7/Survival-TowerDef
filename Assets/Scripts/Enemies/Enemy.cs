using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float enemyHealth;
    public NavMeshAgent navMeshAgent;
    public EnemyScriptableObject enemyScriptableObject;
    //UnityEvent hasDied = new UnityEvent();
    Animator enemyAnim;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        isDead=false;
        navMeshAgent=GetComponent<NavMeshAgent>();
        enemyAnim=GetComponent<Animator>();
        enemyName=enemyScriptableObject.enemyName;
        enemyHealth=enemyScriptableObject.enemyHealth;
        navMeshAgent.speed=enemyScriptableObject.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount){
        enemyHealth=enemyHealth-damageAmount;
        enemyAnim.SetTrigger("takeDamage");
            if(enemyHealth<=0){
                isDead=true;
                enemyAnim.SetBool("isDead",true);
                Destroy(gameObject,1.0f);
            }
    }
}
