using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _button;
    // Start is called before the first frame update

    private void Start()
    {
        _button.onClick.AddListener(OnPlayButtonClickHeandler);
    }

    private void OnPlayButtonClickHeandler()
    {
        BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();
        brickTheBallState.level = 1;
        brickTheBallState.points = 0;
        brickTheBallState.UpdateState(GameState.GameOpened);
    }
}
