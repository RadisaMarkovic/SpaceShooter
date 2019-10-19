using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject[] _powerups = new GameObject[3];

    private Vector3 _randomSpawnPosition;

    private GameManager _gameManager;


    void Start ()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        StartSpawn();
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    public IEnumerator SpawnEnemyRoutine()
    {
        while (_gameManager.isGameOver==false)
        {
            _randomSpawnPosition = new Vector3(Random.Range(-7f, 7f), 7, 0);
           Instantiate(_enemy, _randomSpawnPosition, Quaternion.identity);
           yield return new WaitForSeconds(5.0f);
         
        }
    }

    public IEnumerator SpawnPowerupRoutine()
    {
        while (_gameManager.isGameOver == false)
        {
            _randomSpawnPosition = new Vector3(Random.Range(-7f, 7f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(_powerups[randomPowerup], _randomSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
