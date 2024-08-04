using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs; //����������
    public Camera cam;    

    //�������� ������
    public float startSpawnInterval = 2.0f;
    public float stepInterval = 0.1f;
    public float minInterval = 0.5f;

    private Bounds mapBounds;
    private float currentSpawnInterval;
    private float timerStep = 0f;

    void Start()
    {
        mapBounds = GetComponent<SpriteRenderer>().bounds;//������� ������� �����
        currentSpawnInterval = startSpawnInterval;
        StartCoroutine(SpawnEnemy()); //����� ����������
    }
    
    void Update()
    {
        //���������� ������� ������
        timerStep += Time.deltaTime;
        if (timerStep >= 10f)
        {
            timerStep    = 0f;
            currentSpawnInterval = Mathf.Max(minInterval, currentSpawnInterval - stepInterval);
        }

       
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemyPrefab = GetRandomEnemy(); //����� ���������� ����������
            if (enemyPrefab != null)
            {
                Vector3 spawnPosition = GetRandomPosition(); //��������� �������
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); //�����
            }
             yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    GameObject GetRandomEnemy()
    {
        float randomValue = Random.value; // �������� �� 0 �� 1
        float chance = 0f;

        GameObject selectedPrefab = null;
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            EnemyStats stats = enemyPrefab.GetComponent<EnemyController>().enemyStats;
            chance += stats.SpawnWeight / 100f;

            if (randomValue < chance)
            {
                selectedPrefab = enemyPrefab;
                break;
            }
        }
         //���� ������ �� �������
        if (selectedPrefab == null && enemyPrefabs.Length > 0)
        {
            selectedPrefab = enemyPrefabs[0];
        }

        return selectedPrefab;
    }
    Vector3 GetRandomPosition()
    {
        float spawnDistance = 10f;

        float cameraHeight = 2f * cam.orthographicSize; 
        float cameraWidth = cameraHeight * cam.aspect;
        Vector2 cameraPosition = cam.transform.position;
        Rect cameraBounds = new Rect(cameraPosition.x -cameraWidth / 2, cameraPosition.y - cameraHeight / 2, cameraWidth, cameraHeight);

        Vector3 spawnPosition;        
        do
        {
            float offscreenX = Random.Range(cameraBounds.x - spawnDistance, cameraBounds.x + cameraBounds.width + spawnDistance);
            float offscreenY = Random.Range(cameraBounds.y - spawnDistance, cameraBounds.y + cameraBounds.height + spawnDistance);
            spawnPosition = new Vector2(offscreenX, offscreenY);
        }
        while (cameraBounds.Contains(spawnPosition));

        spawnPosition.x = Mathf.Clamp(spawnPosition.x, mapBounds.min.x, mapBounds.max.x);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, mapBounds.min.y, mapBounds.max.y);
        spawnPosition.z = 0;
            
        return spawnPosition;
    }
}
