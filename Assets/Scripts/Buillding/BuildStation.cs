using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildStation : MonoBehaviour
{
    [SerializeField] Text interactText;
    [SerializeField] GameObject buildCanvasReference;
    [SerializeField] GameObject gridbuilderContainerReference;
    [SerializeField] GameObject buildCamera;
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        interactText.enabled=false;
        SetInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            interactText.enabled=true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag=="Player"&&Input.GetKey(KeyCode.E)){
            other.gameObject.SetActive(false);
            buildCamera.SetActive(true);
            SetActive();
            }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"){
            interactText.enabled=false;
            SetInactive();
        }
    }

    public void SetInactive(){
        buildCanvasReference.SetActive(false);
        gridbuilderContainerReference.SetActive(false);
    }

    public void SetActive(){
        mainCamera.SetActive(false);
        buildCanvasReference.SetActive(true);
        gridbuilderContainerReference.SetActive(true);
    }
}
