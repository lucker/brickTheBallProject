using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickTypes
{
    breakable,
    unbreakable
}

public class Brick : MonoBehaviour
{
    const int POINTS = 100;
    [SerializeField] private BrickTypes _type;
    [SerializeField] private IncreasePlatformPower _increasePlatformPower;
    [SerializeField] private MultiplyBalls _multiplyBalls;
    [SerializeField] private AudioSource _audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_type == BrickTypes.breakable)
        {
            int randNumber = Random.Range(1, 100);
            if (randNumber == 1)
            {
                Instantiate(_increasePlatformPower, transform.position, Quaternion.identity);
            }

            randNumber = Random.Range(1, 10);

            if (randNumber == 2)
            {
                Instantiate(_multiplyBalls, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);

            BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();
            brickTheBallState.points += POINTS;
        }
        //Debug.Log("Brick collision = " + collision.gameObject.name + "Position: " + transform.position);
    }

    public BrickTypes getBrickType()
    {
        return _type;
    }

}