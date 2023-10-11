using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestResource : MonoBehaviour, IInteractable
{
    bool isHarvestable;

    // Start is called before the first frame update
    void Start()
    {
        isHarvestable=false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Interact(){
        if(Input.GetKey(KeyCode.E)&&isHarvestable){
            Debug.Log("you gain trees");
        }
        //play Animation
        //add to inventory
        //disable resource object
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            isHarvestable=true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"){
            isHarvestable=false;
        }
    }

    IEnumerator HarvestCooldown(){
        Interact();
        yield return new WaitForSeconds(1.0f);
    }
}
