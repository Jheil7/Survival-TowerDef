using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class Endpoint : MonoBehaviour
{
    public bool navBool=false;
    [SerializeField] private NavMeshSurface surface;
    ObjectPlacer objectPlacer;
    bool isBuilt=false;


    private void Awake() {
        objectPlacer = GridBuilder2Manager.Instance.ObjectPlacer;
        objectPlacer.IsBuilt.AddListener(()=>{
             if (GridBuilder2Manager.Instance.GridSelector.PreviewObj != gameObject) isBuilt = true;
        });    
    }
    // Start is called before the first frame update
    void Start()
    {
        //Listen for tower build
        //update nav on invoke
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNavMesh();
    }

    void UpdateNavMesh(){
        if(isBuilt==true){
            surface.BuildNavMesh();
            isBuilt=false;
        }
        
    }
}
