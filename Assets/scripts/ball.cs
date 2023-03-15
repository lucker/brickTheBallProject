using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _constantSpeed;
    private int _friction = 5;
    private Vector3 _velocity;
   
    // Start is called before the first frame update
    void Start()
    {
        _velocity = new Vector3(10.0f, 10.0f, 0);
    }

    private void FixedUpdate()
    {
        float velocityMagnitude = _rigidBody2D.velocity.magnitude;
        _rigidBody2D.velocity = _constantSpeed * _rigidBody2D.velocity.normalized;
        //Debug.Log("Velocity: " + velocityMagnitude);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            Platform platform = collision.gameObject.GetComponent<Platform>();
            float speed = platform.getSpeed();
            //Debug.Log("speed " + speed); ;
            if (platform.getIsLeft())
            {
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x - _friction * platform.getSpeed(), _rigidBody2D.velocity.y);
            }

            if (platform.getIsRight())
            {
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x + _friction * platform.getSpeed(), _rigidBody2D.velocity.y);
            }

           
           
            /*if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D platformRigidBody))
            {
                Debug.Log("Platform velocity " + platformRigidBody.velocity);
            }*/
        }
    
        /*if (collision.gameObject.name == "Brick")
        {
            Destroy(collision.gameObject);
        }*/
    }
}
