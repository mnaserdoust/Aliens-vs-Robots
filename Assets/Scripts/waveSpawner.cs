﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    public Transform spawnPoint;

    public Text waveCounDownText;

    private float countDown = 2f;
    private int waveIndex = 0;
    private void Update()
    {
        if(countDown <=0f)
        {
            StartCoroutine( spawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCounDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(.6f);
        }
        
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
