using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;
   
  
  
    void Update ()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y >= 6)
        {
            // if laser have parent object it means it is triple shoot
            if (this.transform.parent != null)
            {
                // destroy the parent and children objects will be destroyed instead of looping trough all lasers objects
                Destroy(this.transform.parent.gameObject);
            }
            // if it doesn't have parent destroy only this laser object
            else
            {
            
                Destroy(this.gameObject);
            }
           
        }
    }
}
