using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMPro.TMP_Dropdown _dropDown;
    // Start is called before the first frame update

    private void Start()
    {
        _button.onClick.AddListener(OnPlayButtonClickHeandler);
        //_dropDown.onValueChanged.AddListener(OnDropdownChange);
    }

    private void OnPlayButtonClickHeandler()
    {
        BrickTheBallState brickTheBallState = BrickTheBallState.GetInstance();
        brickTheBallState.level = 1;
        brickTheBallState.points = 0;
        brickTheBallState.mode = _dropDown.value;
        brickTheBallState.UpdateState(GameState.GameOpened);
    }

    /*private void OnDropdownChange(int value)
    {
        Debug.Log(value);
    }*/
}
