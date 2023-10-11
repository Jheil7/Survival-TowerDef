using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    private GameObject enemyToSpawn;
    private float timeBetweenSpawns;
    private float amountToSpawn;
    private int spawnTimer;
    public WaveSO waveScriptableObject;
    CaveCamera batEvent;
    Vector3 startPointV3;
    [SerializeField] Text timerText;
    CanvasGroup canvasGroup;
    int countdown;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        canvasGroup=timerText.GetComponent<CanvasGroup>();
        canvasGroup.alpha=0;
        enemyToSpawn=waveScriptableObject.enemy;
        timeBetweenSpawns=waveScriptableObject.spawnDelay;
        amountToSpawn=waveScriptableObject.enemiesToSpawn;
        spawnTimer=waveScriptableObject.timeUntilSpawn;
        startPointV3=new Vector3(transform.position.x, 0f, transform.position.z);
        batEvent=FindObjectOfType<CaveCamera>();
        batEvent.CaveTrigger.AddListener(()=>{
            StartCoroutine(SpawnEnemies());
            });
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies(){
        countdown=spawnTimer;
        canvasGroup.alpha=1;
        Debug.Log(countdown);
        for(int i=countdown; i>=0; i--){
            timerText.text="Time until Bat Attack: "+countdown.ToString();
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }
        canvasGroup.alpha=0;
        for(int i=0; i<amountToSpawn; i++){
            Instantiate(enemyToSpawn,startPointV3,transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }


}
