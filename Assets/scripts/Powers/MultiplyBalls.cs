using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MultiplyBalls : Powers
{
    [SerializeField] private Ball _ball;

    public override void ImplementPower(GameObject gameObjectPowerImplementsTo)
    {
        GameObject BallObject = GameObject.Find("Ball");
        Rigidbody2D ballRigidbody2D = BallObject.GetComponent<Rigidbody2D>();
       
        //Debug.Log("Position ball " + BallObject.transform.position);
        Ball newBallObject = Instantiate(_ball, BallObject.transform.position, Quaternion.identity);
        if (newBallObject.TryGetComponent<Rigidbody2D>(out var newBallRigidbody2D))
        {

            newBallRigidbody2D.velocity = ballRigidbody2D.velocity;
        }
    }
}
