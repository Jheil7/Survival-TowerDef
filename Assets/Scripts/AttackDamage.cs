using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{

    private float itemDamage;
    Enemy enemy;
    [SerializeField ] PlayerWeaponSO playerWeaponSO;
    public bool hasDamaged;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        hasDamaged=true;
        // animator=gameObject.GetComponentinP<Animator>();
        itemDamage=playerWeaponSO.weaponDamage;
        animator=transform.parent.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwingAttack();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Enemy"&&!hasDamaged){
            enemy=other.GetComponent<Enemy>();
            enemy.TakeDamage(itemDamage);
            hasDamaged=true;
        }
    }
    void SwingAttack(){
        if(Input.GetMouseButtonDown(0)){
            hasDamaged=false;
            animator.SetTrigger("Attack");
            StartCoroutine("CanDamage");
            
        }
    }

    IEnumerator CanDamage(){
        yield return new WaitForSeconds(0.3f);
        hasDamaged=true;
    }
}
