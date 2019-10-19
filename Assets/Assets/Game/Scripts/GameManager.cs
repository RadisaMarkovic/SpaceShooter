using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isGameOver;
    
    private UIManager _uiManager;

    [SerializeField]
    private GameObject _player;

   


    public void Start()
    {
        isGameOver = true;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
       
    }


    private void Update()
    {
        //If game is over wait for player to press space to start new game
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Disable title screen and spawn player
                _uiManager.HideTitleScreen();
                Instantiate(_player, new Vector3(0, 0, 0), Quaternion.identity);
                isGameOver = false;
               

            }
        }

       
    }
}
