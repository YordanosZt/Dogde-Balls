using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball ballPrefab;

    public float spawnRate = 1f;
    public float spawnDistance = 25f;
    public float trajectoryVariance = 15f;
    
    public int spawnAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);   
    }

    void Spawn(){
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Ball ball = Instantiate(ballPrefab, spawnPoint, rotation);
            ball.size = Random.Range(ball.minSize, ball.maxSize);
            ball.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
