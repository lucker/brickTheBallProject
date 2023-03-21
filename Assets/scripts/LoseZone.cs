using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
            collision.gameObject.SetActive(false);
        }

        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();
            brickTheBallState.UpdateState(GameState.Lose);
        }
    }
}
