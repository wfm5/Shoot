using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
    public int numberOfEnemies;
    private float spawnRadius = 5f;
    private Vector3 spawnPos;
    private GameManager_EventMaster EventMasterScript;

    void OnEnable()
    {
        SetInit();
        EventMasterScript.myGeneralEvent += SpawnObject;
    }
    void OnDisable()
    {
        EventMasterScript.myGeneralEvent -= SpawnObject;
    }

    void SetInit()
    {
        EventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
    }
    // Use this for initialization
	void Start () {
        //SpawnObject();

	}
		
    void SpawnObject()
    {
        for(int i = 0; i<numberOfEnemies; i++){
            spawnPos= transform.position+Random.insideUnitSphere*spawnRadius;
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
