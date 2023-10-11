using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CaveCamera : MonoBehaviour
{

    [SerializeField] GameObject cutsceneCam;
    public UnityEvent caveTrigger = new UnityEvent();


    public UnityEvent CaveTrigger{
        get{return caveTrigger;}
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            gameObject.GetComponent<BoxCollider>().enabled=false;
            cutsceneCam.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(FinishCut(other.gameObject));
        }
    }

    IEnumerator FinishCut(GameObject playerObject){
        yield return new WaitForSeconds(6);
        playerObject.SetActive(true);
        cutsceneCam.SetActive(false);
        caveTrigger.Invoke();
        
    }
}
