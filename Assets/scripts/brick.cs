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
        BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();
        Debug.Log("mode:" + brickTheBallState.mode + "easy: " + brickTheBallState.EASY);

        if (_type == BrickTypes.breakable)
        {
            int randNumber = 0;
            int randNumber2 = 0;

            if (brickTheBallState.mode == brickTheBallState.EASY)
            {
                Debug.Log("3213");
                randNumber = Random.Range(1, 50);
                randNumber2 = Random.Range(1, 4);
            }

            if (brickTheBallState.mode == brickTheBallState.MEDIUM)
            {
                randNumber = Random.Range(1, 100);
                randNumber2 = Random.Range(1, 10);
            }

            if (brickTheBallState.mode == brickTheBallState.HARD)
            {
                randNumber = Random.Range(1, 200);
                randNumber2 = Random.Range(1, 20);
            }
            Debug.Log("mode:" + brickTheBallState.mode + "easy: " + brickTheBallState.EASY + "RandomNumber: " + randNumber2);

            if (randNumber == 1)
            {
                Instantiate(_increasePlatformPower, transform.position, Quaternion.identity);
            }

            if (randNumber2 == 2)
            {
                Instantiate(_multiplyBalls, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);

           
            brickTheBallState.points += POINTS;
        }
        //Debug.Log("Brick collision = " + collision.gameObject.name + "Position: " + transform.position);
    }

    public BrickTypes getBrickType()
    {
        return _type;
    }

}