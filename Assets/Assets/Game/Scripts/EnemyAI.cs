using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    public int health = 2;

    [SerializeField]
    private GameObject _enemyExplosionPref;

    [SerializeField]
    private AudioClip _explosionAudioClip;

    private UIManager _uiManager;

    
    void Start ()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    
    
    void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //if enemy is of screen and have not been killed can spawn new enemy
        if (transform.position.y < -6)
        {
            SpawnEnemy();
        }
    }



    void SpawnEnemy()
    {
        //spawn enemy at random x position that is in range of view
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
        
    }


// if player colided with player take damage and enemy is destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage();
                Instantiate(_enemyExplosionPref, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_explosionAudioClip, Camera.main.transform.position);
                Destroy(this.gameObject);

            }


        }

        
        // if laser colided with enemy destroy enemy and laser
        else if (other.CompareTag("Laser"))
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            else
            {
                Destroy(other.gameObject);
            }
            Instantiate(_enemyExplosionPref, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_explosionAudioClip, Camera.main.transform.position);
            Destroy(this.gameObject);

        }

        // update player score
        _uiManager.UpdateScore();
    }
}
