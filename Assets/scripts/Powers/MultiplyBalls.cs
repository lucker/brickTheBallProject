using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MultiplyBalls : Powers
{
    [SerializeField] private Ball _ball;

    public override void ImplementPower(GameObject gameObjectPowerImplementsTo)
    {
        GameObject[] BallObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject BallObject in BallObjects) {
            Rigidbody2D ballRigidbody2D = BallObject.GetComponent<Rigidbody2D>();

            //Debug.Log("Position ball " + BallObject.transform.position);
            Ball newBallObject = Instantiate(_ball, BallObject.transform.position, Quaternion.identity);
            if (newBallObject.TryGetComponent<Rigidbody2D>(out var newBallRigidbody2D))
            {
                newBallRigidbody2D.velocity = ballRigidbody2D.velocity;

                newBallRigidbody2D.velocity = Rotate(newBallRigidbody2D.velocity, 5);
            }
        }
    }

    public static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
