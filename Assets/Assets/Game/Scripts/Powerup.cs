using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; //0 = tripleShoot; 1 = speedBoost; 2 = shield

    [SerializeField]
    private AudioClip _powerupAudioClip;
   
    void Start ()
    {
        
    }
    
    
    void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_powerupAudioClip, Camera.main.transform.position);
            if (player != null)
            {
                //check which powerup the player picked and activate that powerup
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }

                else if (powerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }

                else if (powerupID == 2)
                {
                    player.ShieldPowerupOn();
                }
                    
               
            }

            Destroy(this.gameObject);
        }
    }
    
        
    
}
