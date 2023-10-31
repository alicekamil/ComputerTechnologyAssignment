using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private int hazardCount = 10;
    [SerializeField]
    private Vector3 spawnValues;
    [SerializeField] 
    private float spawnWait;
    [SerializeField]
    private float startWait;
    [SerializeField] 
    private float waveWait;
    
    private bool gameOver;
    private bool restart;
    private int score;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    
    
    public GameObject hazard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        gameOver = false;
        restart = false;
        //restartButton.gameObject.SetActive(false);
        
        score = 0;
        UpdateScore();
        //StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score " + score;
    }
}
