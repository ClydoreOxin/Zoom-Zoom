using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject playerPos;
    public GameObject groundPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;
    public PlayerMovement playerMoveRef;
    public Vector3 spawnRange;
    public float rateOfSpawn = 1;
    public int typeOfWall;
    public bool spawnTime = true;
    public float score;
    public int wallsPerFrame = 3;
    public float tempScore = 20;
    public float speedSet = 60;
    public int difficulty = 1;
    float tScoreMod = 25;
    float setSpeedMod = 10;
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadScore();
        playerPos = GameObject.Find("Player");
        playerMoveRef = playerPos.GetComponent<PlayerMovement>();
        score = 0;
        StartCoroutine(SpawnWalls());
        restartButton.gameObject.SetActive(false);
        if (MainManager.Instance.highScore != 0)
        {
            
            highScoreText.text = "High Score: " + MainManager.Instance.highScore;
        }

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (tempScore < score)
        {
            rateOfSpawn -= 0.1f;
            tempScore += tScoreMod;
            speedSet += setSpeedMod;

            if (tempScore == 100)
            {
                tScoreMod *= 2;
                setSpeedMod /= 2;
            }
            if (tempScore == 200) 
            {
                tScoreMod = 100;
                setSpeedMod /= 2;
            }
        }
        if (!playerMoveRef.isGameActive) {
            MainManager.Instance.highScore = score;
            restartButton.gameObject.SetActive(true);
        }
    }
    IEnumerator SpawnWalls() {
        while (spawnTime)
        {
            yield return new WaitForSeconds(rateOfSpawn);
            for (int index = 0; index < wallsPerFrame; index++) {
                NumberOfWalls();
            }
        }
    }
    public void SpawnGrounds()
    {
        Instantiate(groundPrefabs, new Vector3(0,0,245), transform.rotation);
    }
    public void NumberOfWalls() {
        typeOfWall = Random.Range(0, wallPrefabs.Length);
        spawnRange = new Vector3(Random.Range(-50, 50), 0, transform.position.z);
        Instantiate(wallPrefabs[typeOfWall], spawnRange,
                    wallPrefabs[typeOfWall].transform.rotation);
    }
   
}
