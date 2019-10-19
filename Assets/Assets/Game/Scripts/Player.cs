using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float _speed = 5.0f;
    private float _newSpeed;

    private Vector3 playerDirection;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _shield;

    [SerializeField]
    private GameObject[] _engineFailures;

    private UIManager _uiManager;

    private GameManager _gameManager;
    private SpawnManager _spawnManager;

    [SerializeField]
    private float _fireRate = 1.5f;
    private float _canFire = 0.0f;
    private int _hitCount;


    
    private AudioSource _audioSource;
    
    private bool canTripleShot = false;
    private bool canSpeedBoost = false;

    private int health = 3;
    private bool isShieldEnabled = false;
    
    public bool IsShieldEnabled { get { return isShieldEnabled; } } 

    void Start ()
    {
        //starting position of _player
        transform.position = new Vector3(0, 0, 0);
        _newSpeed = _speed;
        playerDirection = Vector3.zero;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();

        _spawnManager.StartSpawn();
        _uiManager.UpdateLives(health);
        _hitCount = 0;
    }
    
    
    void Update ()
    {
        Movement();

        //if space key is pressed
        //spawn laser
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
           Shoot();
        }
        
       
    }



    private void Movement()
    {
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        // increase speed by 1.5 if speedbost is picked up
        if (canSpeedBoost == true)
        {
            _newSpeed = _speed * 1.5f;
        }

        else
        {
            _newSpeed = _speed;
        }

        // move the player
        transform.Translate(playerDirection * Time.deltaTime * _newSpeed);


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.2)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        else if (transform.position.x > 9.5)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }

        else if (transform.position.x < -9.5)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }


    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();
            if (canTripleShot)
            {
                Instantiate(_tripleLaserPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
        
            _canFire = Time.time + _fireRate;
        }
    }

    public void TripleShotPowerupOn()
    {
        StartCoroutine(TripleShotPowerDownRoutine());
        canTripleShot = true;
    }

    public void ShieldPowerupOn()
    {
        isShieldEnabled = true;
        _shield.SetActive(true);
    }

    public void SpeedBoostPowerupOn()
    {
        StartCoroutine(SpeedBostPowerDownRoutine());
        canSpeedBoost = true;
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    IEnumerator SpeedBostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedBoost = false;
    }

    public void TakeDamage()
    {
        if (isShieldEnabled == false)
        {
            

            this.health--;
            _uiManager.UpdateLives(health);

            


            if (health <= 0)
            {
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                _gameManager.isGameOver = true;
                _uiManager.ShowTitleScreen();


            }


            _hitCount++;

            switch (_hitCount)
            {
                case 1:
                    _engineFailures[0].SetActive(true);
                    break;
                case 2:
                    _engineFailures[1].SetActive(true);
                    break;
            }
        }


        else
        {
            isShieldEnabled = false;
            _shield.SetActive(false);
        }
         
        

        
    }
}
