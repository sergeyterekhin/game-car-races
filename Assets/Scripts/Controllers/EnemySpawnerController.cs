using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private float delaySpawn;
    [SerializeField] private int countSpawnObject;
    [SerializeField] private int poolLength;
    private GameObject[] poolObject;
    private float spawnRadius;
    private Vector3 centerPivot;
    void Start()
    {
        spawnRadius = this.GetComponent<CircleCollider2D>().radius;
        centerPivot = this.transform.position;
        poolObject = ElementCreator.CreatePool(poolLength, enemyList);
        StartCoroutine(CreateObjects());
    }

    IEnumerator CreateObjects()
    {
        while (true)
        {
            for(int i=0; i<countSpawnObject; i++) { 
                GameObject spawnObject = ElementCreator.getPoolObject(poolObject);
                if (spawnObject != null) { 
                    Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                    spawnPos.x += centerPivot.x;
                    spawnPos.y += centerPivot.y;
                    spawnObject.transform.position = spawnPos;
                    spawnObject.GetComponent<IPoolObject>().ActivePool();
                }
            }
            yield return new WaitForSeconds(delaySpawn);
        }
    }

}
