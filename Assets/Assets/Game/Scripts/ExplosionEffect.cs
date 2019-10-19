using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

	
	void Start ()
	{
		//destroy explosion effect after 3 seconds
		Destroy(this.gameObject, 3f);
		
	}
	
	
}
