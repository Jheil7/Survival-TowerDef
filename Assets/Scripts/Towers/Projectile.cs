using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ProjectileScriptableObject projectileScriptableObject;
    public float projectileDamage;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        projectileDamage=projectileScriptableObject.projectileDamage;
        Destroy(gameObject,3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Enemy"){
            enemy=other.GetComponent<Enemy>();
            enemy.TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
