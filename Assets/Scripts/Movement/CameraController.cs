using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    Vector2 rawInput;
    [SerializeField] float cameraSpeed=1.0f;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject mainCamera;
    BuildStation buildStation;
    // Start is called before the first frame update
    void Start()
    {
        buildStation=FindObjectOfType<BuildStation>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        EnablePlayer();
    }

    void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();

    }
    void CameraMove(){
        transform.position=new Vector3(transform.position.x+(rawInput.x*cameraSpeed), transform.position.y, transform.position.z+(rawInput.y*cameraSpeed));
    }

    void EnablePlayer(){
        if(Input.GetKey(KeyCode.Escape)){
            buildStation.SetInactive();
            playerObject.SetActive(true);
            mainCamera.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }


}
