using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private int _jumpCheck, _playerCoins, _playerLives = 3;
    private UIManager _uiManager;
    private Vector3 _postionSave;
    private bool _singleLiveLost = false;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateLivesDisplay(_playerLives);
        _postionSave = new Vector3((float)-5.5, (float)0.7, 0);


        if (_uiManager == null)
        {
            Debug.LogError("The UI manager is null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Define movement direction
        Vector3 direction = new Vector3(horizontalInput, _yVelocity, verticalInput);

        //direction with speed
        Vector3 velocity = direction * _speed;

        //apply gravity if the character is not grounded and check for double jump
        if(_controller.isGrounded == true || _jumpCheck < 2)
        {
            //check if the spacebar has been pressed and increase double jump counter
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _jumpCheck++;
            }

            //check if the player is in the air, if necessary apply gravity
            if(_controller.isGrounded == false )
            {
                _yVelocity -= _gravity;
            }

            // check if double jump has been concluded
            if (_jumpCheck == 2 && _controller.isGrounded == true)
            {
                _jumpCheck = 0;
            }

        }
        else
        {
            _yVelocity -= _gravity;
        }

        //Move character
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -100 && _singleLiveLost == false)
        {
            SubStractLives();
            transform.position = _postionSave;
            //reset game
            //respawn
        }
        else if(transform.position.y > - 30 )
        {
            _singleLiveLost = false;
        }


    }

    public void PowerUp(string _powerType)
    {

        switch (_powerType)
        {
            case "ShrinkPod":
                transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                break;
            case "GrowthPod":
                transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                break;
        }
    }

    


    public void AddCoins()
    {
        _playerCoins++;

        _uiManager.UpdateCoinDisplay(_playerCoins);
    }

    public void SubStractLives()
    {
        if (_playerLives > 0)
        {
            _playerLives--;
            _uiManager.UpdateLivesDisplay(_playerLives);
            _singleLiveLost = true;
        }
        else
        {
            //restart game
        }

    }
}
