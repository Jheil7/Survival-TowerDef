using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerFire : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    float fireRate=1.0f;
    GameObject projectileInstance;
    List<GameObject> enemiesInRange;
    public bool isFiring=false;
    public bool isBuilt;
    GridObject gridObject;
    ObjectPlacer objectPlacer;
    Enemy enemy;

    // Start is called before the first frame update
    void Awake(){
        objectPlacer = GridBuilder2Manager.Instance.ObjectPlacer;
        objectPlacer.IsBuilt.AddListener(()=>{
             if (GridBuilder2Manager.Instance.GridSelector.PreviewObj != gameObject) isBuilt = true;
        });       
    }
    
    void Start()
    {
        enemiesInRange= new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFiring&&isBuilt&&enemiesInRange.Count>0){
            if(enemiesInRange[0]!=null){
                StartCoroutine("FireWait");
            }
            else{
                enemiesInRange.RemoveAt(0);
            }
            
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Enemy"){
            enemiesInRange.Add(other.gameObject);
            enemy=other.GetComponent<Enemy>();
            
        //     enemy.HasDied.AddListener(()=>{
        //     enemiesInRange.RemoveAt(0);
        //     enemy.HasDied.RemoveListener(()=>{});
        // });
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Enemy"){
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void Fire(Vector3 targetTransform){
        projectileInstance=Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody projectileRb=projectileInstance.GetComponent<Rigidbody>();
        Vector3 direction = targetTransform - projectileInstance.transform.position;
        Vector3 velocity = direction.normalized * projectileSpeed;
        projectileRb.velocity = velocity;


    }

    IEnumerator FireWait(){
        isFiring=true;
        Vector3 target=enemiesInRange[0].transform.position;
        
        if(target!=null){
            Fire(target);
        }
        yield return new WaitForSeconds(fireRate);
        isFiring=false;
    }

    // void FireIfTarget(){
    //     if(enemiesInRange.Count>0){
    //         StartCoroutine("FireWait");
    //     }
    // }

    void CheckBuildStatus(){
        isBuilt=true;
        
    }
}
