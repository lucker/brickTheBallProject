using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Platform _platform;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private BrickTheBallState _brickTheBallState;

    private void Awake()
    {
        _brickTheBallState = BrickTheBallState.GetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _brickTheBallState.getState() == GameState.GameOpened) {
            _brickTheBallState.UpdateState(GameState.GameInProcess);
            _ball.AddForce();
        }
    }

    private void FixedUpdate()
    {
        if (_brickTheBallState.getState() == GameState.GameInProcess)
        {
            _textMeshPro.text = "POINTS: " + _brickTheBallState.points;
            //GameObject[] BallObjects = GameObject.FindGameObjectsWithTag("Ball");
            GameObject[] brickObjects = GameObject.FindGameObjectsWithTag("Brick");
            bool win = true;

            foreach (GameObject brickObject in brickObjects)
            {
                Brick brick = brickObject.GetComponent<Brick>();

                if (brick != null && brick.getBrickType() != BrickTypes.unbreakable)
                {

                    win = false;
                }
            }

            if (win) {
                _brickTheBallState.UpdateState(GameState.Win);
            }
        }

        if (_brickTheBallState.getState() == GameState.Win)
        {
            _textMeshPro.text = "POINTS: " + _brickTheBallState.points;
        }
    }
}