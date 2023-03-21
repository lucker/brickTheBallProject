using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _audioClip;
    private float _friction = 0.2f;
    private float _constantSpeed = 10.0f;

    private void FixedUpdate()
    {
        BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();

        if (brickTheBallState.getState() == GameState.GameInProcess)
        {
            _rigidBody2D.velocity = _constantSpeed * _rigidBody2D.velocity.normalized;

            if (_rigidBody2D.velocity.y < 5.0f && _rigidBody2D.velocity.y >= 0) {
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, 5.0f);
            }

            if (_rigidBody2D.velocity.y <= 0 && _rigidBody2D.velocity.y < -5.0f)
            {
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, -5.0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ball trigger");
        if (collision.gameObject.name == "Platform")
        {
            Platform platform = collision.gameObject.GetComponent<Platform>();
            Rigidbody2D rigidbody2D = platform.GetComponent<Rigidbody2D>();
            _rigidBody2D.velocity += _friction * rigidbody2D.velocity;
   
        }
        //_audio.PlayOneShot(_audioClip);
    }

    public void AddForce()
    {
        //Debug.Log("AddForce");
        _rigidBody2D.AddForce(new Vector2(10f, 50f));
    }
}