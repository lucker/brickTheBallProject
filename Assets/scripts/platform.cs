using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum movemantState
{
    movingRight,
    movingLeft,
    notMoving
}

public class Platform : MonoBehaviour
{
    //[SerializeField] private GameObject _gameOver;
    private float _speed = 35f;
    private bool _canMoveLeft = true;
    private bool _canMoveRight = true;
    private movemantState _movemantState = movemantState.notMoving;

    private void FixedUpdate()
    {
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, 0);

        if (_movemantState == movemantState.movingLeft && _canMoveLeft)
        {
            rigidbody2D.velocity = new Vector2(-_speed, 0);
        }

        if (_movemantState == movemantState.movingRight && _canMoveRight)
        {
            rigidbody2D.velocity = new Vector2(_speed, 0);
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("Exit collision " + collision.gameObject.name);

        if (collision.gameObject.name == "LeftWall"
            || collision.gameObject.name == "RightWall"
        )
        {
            _canMoveRight = true;
            _canMoveLeft = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Platform collision " + collision.gameObject.name);
        //_canMoveRight = true;
        //_canMoveLeft = true;

        if (collision.gameObject.name == "LeftWall")
        {
            _canMoveLeft = false;
        }

        if (collision.gameObject.name == "RightWall")
        {
            _canMoveRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();

        if (brickTheBallState.getState() == GameState.GameInProcess) {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _movemantState = movemantState.movingLeft;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                _movemantState = movemantState.notMoving;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _movemantState = movemantState.movingRight;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                _movemantState = movemantState.notMoving;
            }
        }
    }
}
