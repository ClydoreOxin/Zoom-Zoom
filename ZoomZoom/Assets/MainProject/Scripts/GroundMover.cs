using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public WallSpawner wallSpawnRef;
    public Vector3 startPos;
    public float halfway;
    // Start is called before the first frame update
    void Start()
    {
        wallSpawnRef = GameObject.Find("WallSpawner").GetComponent<WallSpawner>();
        startPos = transform.position;
        halfway = transform.position.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Background"))
        {
            transform.Translate(Vector3.right * wallSpawnRef.speedSet * Time.deltaTime);
            if (transform.position.z < 0)
            {
                transform.position = startPos;
            }
        }
            
        if (gameObject.CompareTag("Ground"))
        {
            transform.Translate(Vector3.back * wallSpawnRef.speedSet * Time.deltaTime);
            if (transform.position.z < -50)
            {
                wallSpawnRef.SpawnGrounds();
                Destroy(gameObject);
            }
        }
    }
}
