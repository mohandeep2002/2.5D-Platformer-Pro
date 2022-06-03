using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool _canDoubleJump;
    [SerializeField]
    private int _coins;
    [SerializeField]
    private UIManager _uIManager;
    [SerializeField]
    private int _lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uIManager == null)
        {
            Debug.LogError("UI Manager Object not created in player.cs");
        }
        _uIManager.UpdateLives(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _yVelocity = _yVelocity - _gravity;
        }
        velocity.y = _yVelocity;  
        _controller.Move(velocity * Time.deltaTime);
    }
    public void AddCoin()
    {
        _coins++;
        _uIManager.UpdateCoins(_coins);
    }
    public void DeleteLives()
    {
        _lives--;
        _uIManager.UpdateLives(_lives);
        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
