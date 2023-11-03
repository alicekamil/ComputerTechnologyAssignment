using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Entities;


public class GameManager : MonoBehaviour
{
    private EntityQuery playerQuery;

    private GameObject playerPrefab;
    public static GameManager Instance { get; private set; }

    /*
     //public GameObject hazard;

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
    */

    private bool gameOver;
    public TextMeshProUGUI gameOverText;
    /*private bool restart;
    private int score;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    
    */

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        gameOver = false;
        gameOverText.SetText("");
    }

    private void Start()
    {
        playerQuery =
            World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<PlayerTag>());
        
        //restartButton.gameObject.SetActive(false);
        //score = 0;
        //UpdateScore();
        //StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (playerQuery.IsEmpty && Time.time > 2f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverText.SetText("GAME OVER");
        gameOver = true;
        //restartButton.gameObject.SetActive(true);
    }

    /*public void Restart()
    {
        //SceneManager.LoadScene(0);

        /*var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        entityManager.DestroyEntity(entityManager.UniversalQuery);
        World.DisposeAllWorlds();
        DefaultWorldInitialization.Initialize("Default World", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

        gameOverText.text = "";
        restartButton.gameObject.SetActive(false);
        */

        /*World.DefaultGameObjectInjectionWorld.EntityManager.Instantiate();
        playerQuery =
            World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
                ComponentType.ReadOnly<PlayerTag>());
    }



    /*IEnumerator SpawnWaves()
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
    */
        
}

