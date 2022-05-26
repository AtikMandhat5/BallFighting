using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
	public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber=1;
	private float spwanRange =9.0f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);

    }

// Update is called once per frame
    void Update()
    {
        enemyCount=FindObjectsOfType<Enemy>().Length;

        if(enemyCount==0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
                Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
        }

    }
    
    //create span
    void SpawnEnemyWave(int enemiesToSpawn){

        for(int i=0;i<enemiesToSpawn;i++)
        {

        Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition(){
		
		float spwanX= Random.Range(-spwanRange,spwanRange);
	   	float spwanZ= Random.Range(-spwanRange,spwanRange);
    

    	Vector3 randomPos= new Vector3(spwanX,0,spwanZ);
        	
        return randomPos;

    }
}
