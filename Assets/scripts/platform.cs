using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isLeft;
    private bool _isRight;
    private bool _wallLeft;
    private bool _wallRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (_isLeft && !_wallLeft)
        {
            transform.position = transform.position - new Vector3(_speed, 0, 0);
            _wallRight = false;
        }

        if (_isRight && !_wallRight)
        {
            _wallLeft = false;
            transform.position = transform.position + new Vector3(_speed, 0, 0);
        }
        //Transform.AddForce
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wall Trigger" + collision.gameObject.name);
        if (collision.gameObject.name == "LeftWall")
        {
            _wallLeft = true;
        }

        if (collision.gameObject.name == "RightWall")
        {
            _wallRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _isLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _isRight = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _isRight = false;
        }
    }
}
