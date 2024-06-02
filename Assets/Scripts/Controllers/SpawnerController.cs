using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private int poolLength;
    [SerializeField] private bool checkCollision;
    [SerializeField] private string collisionMaskIfExsist;
    [SerializeField] private float delaySpawn;
    [SerializeField] private int minObject;
    [SerializeField] private int maxObject;
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

    protected bool HasObjectsInArea(GameObject SpawnObj)
    {
        ContactFilter2D contactFilter = new();
        contactFilter.SetLayerMask(LayerMask.GetMask(collisionMaskIfExsist));
        contactFilter.useTriggers = false;
        contactFilter.useLayerMask = true;
        SpawnObj.SetActive(true);
        int collisionCount = SpawnObj.GetComponent<Collider2D>().OverlapCollider(contactFilter, new Collider2D[10]);
        SpawnObj.SetActive(false);
        if(collisionCount > 0) Debug.Log("Есть коллизии: "+SpawnObj.tag);
        return collisionCount>0;
    }

    IEnumerator CreateObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaySpawn);
            int countSpawnObject = Random.Range(minObject, maxObject+1);
            for (int i=0; i<countSpawnObject; i++) { 
                GameObject spawnObject = ElementCreator.getPoolObject(poolObject);
                if (spawnObject != null) { 
                    Vector2 spawnPos = Random.insideUnitCircle * spawnRadius;
                    spawnPos.x += centerPivot.x;
                    spawnPos.y += centerPivot.y;
                    spawnObject.transform.position = spawnPos;
                    if (checkCollision)
                    {
                        while (HasObjectsInArea(spawnObject))
                        {
                            spawnPos = Random.insideUnitCircle * spawnRadius;
                            spawnPos.x += centerPivot.x;
                            spawnPos.y += centerPivot.y;
                            spawnObject.transform.position = spawnPos;
                        }
                    }
                    spawnObject.GetComponent<IPoolObject>().ActivePool();
                }
            }
        }
    }

}
