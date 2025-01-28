using System.Collections.Generic;
using UnityEngine;

public class BirdSpanwer : MonoBehaviour
{
    public GameObject birdPrefab;
    private float timeBetweenWaves = 7f;
    private float nextTimeForWave = 0.5f;
    public static int BIRD_COUNT = 0;

    private void Update()
    {
        if (Time.timeSinceLevelLoad >= nextTimeForWave)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        int waveCount = Random.Range(1, 3);

        if (BIRD_COUNT + waveCount <= 8) // maximum 8 on the screen
        {
            for (int i = 0; i < waveCount; i++)
            {
                Instantiate(birdPrefab, new Vector3(Random.Range(-7f, 7f), -4.5f, 0), Quaternion.identity, this.transform);
                BirdSpanwer.BIRD_COUNT++;
            }

            nextTimeForWave = Time.timeSinceLevelLoad + timeBetweenWaves + waveCount*2;
        }
    }
}
