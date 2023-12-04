using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    public Quaternion spawnRotate;
    public Detection detection;
    public float spawnTime = 0.5f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detection.detect.Count > 0)
        {
            timer += Time.deltaTime;

            if (timer >= spawnTime)
            {
                Instantiate(projectile, spawnLocation1.position, spawnRotate);
                if (Random.Range(5, 10) % 2 == 0) {
                    Instantiate(projectile, spawnLocation2.position, spawnRotate);
                }
                timer = 0;
            }
        }
        else {
            timer = 0.5f;
        }
        
    }
}
