using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallMovement : MonoBehaviour
{
    public Rigidbody wallRb;
    public GameObject wallPrefab;
    public WallSpawner wallSpawnScript;


    // Start is called before the first frame update
    private float speed;
    void Start() {
        wallSpawnScript = GameObject.Find("WallSpawner").GetComponent<WallSpawner>();
        speed = wallSpawnScript.speedSet;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        
        
        if (transform.position.z <= -15)
        { DeathAndScore(); }
    }
    public void DeathAndScore() {
            wallSpawnScript.score += 1;
            Destroy(gameObject);
    }
}
