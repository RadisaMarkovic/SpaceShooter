using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _anim;
	
	void Start ()
    {
        _anim = GetComponent<Animator>();
	}
	

	void Update ()
    {
        // if player pressed the button for left movement play animation for left and disable for right
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("IsPlayerLeft", true);
            _anim.SetBool("IsPlayerRight", false);
        }

        // if player pressed the button for right movement play animation for right and disable for left
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("IsPlayerRight", true);
            _anim.SetBool("IsPlayerLeft", false);
        }

        // if player released buttons for left movement disable animations
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("IsPlayerRight", false);
            _anim.SetBool("IsPlayerLeft", false);
        }

        // if player released the buttons for right movement disable animations
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("IsPlayerRight", false);
            _anim.SetBool("IsPlayerLeft", false);
        }
    }
}
