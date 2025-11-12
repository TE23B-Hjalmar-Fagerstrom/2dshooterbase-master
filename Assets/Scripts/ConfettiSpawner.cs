using System;
using UnityEngine;

public class ConfettiSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject confetti;

    float timeSincelastSpawn = 0;
    [SerializeField]
    float timeBetweenSpawns = 0.1f;

    void Update()
    {
        timeSincelastSpawn += Time.deltaTime;

        if (timeSincelastSpawn >= timeBetweenSpawns)
        {
            Instantiate(confetti);
            timeSincelastSpawn = 0;
            Console.WriteLine("hej");
        } 
    }
}
