using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _force;
    private bool _started = false;
    private float _littleForce = 30f;
    // Start is called before the first frame update
    void Start()
    {
        //_rigidBody2D.AddForce(new Vector2(0.5f, 0.5f) * _force, ForceMode2D.Force);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !_started)
        {
            _rigidBody2D.AddForce(new Vector2(0.5f, 0.5f) * _force, ForceMode2D.Force);
            _started = true;
        }

        //_rigidBody2D.AddForce(Vector2.up * _littleForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ball collosion = " + collision.gameObject.name);
        if (collision.gameObject.name == "Brick")
        {
            Destroy(collision.gameObject);
        }

        if (_started && collision.gameObject.name == "Platform")
        {
            _rigidBody2D.AddForce(Vector2.up * _littleForce, ForceMode2D.Force);
            //    Debug.Log(collision.gameObject.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
