using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BrickTheBallState
{
    public const int LEVEL_1 = 1;
    public const int MAX_LEVEL = 2;
    public int EASY = 0;
    public int MEDIUM = 1;
    public int HARD = 2;
    private static BrickTheBallState _instance;
    private GameState _state;
    public int level;
    public int points;
    public int mode;
    private BrickTheBallState() { }

    public static BrickTheBallState GetInstance()
    {
        if (_instance == null) {
            _instance = new BrickTheBallState();
            _instance._state = GameState.InMainMenu;
            _instance.level = LEVEL_1;
            _instance.points = 0;
            _instance.mode = _instance.EASY;
        }

        return _instance;
    }

    public void UpdateState(GameState state)
    {
        _state = state;

        switch (_state)
        {
            case GameState.GameOpened:
                SceneManager.LoadScene("Level" + level);
                break;

            case GameState.GameInProcess:

                break;

            case GameState.Lose:
                foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                {
                    if (gameObject.name == "GameOverText")
                    {
                        gameObject.SetActive(true);
                    }
                }

                SceneManager.LoadScene("Menu");
                _state = GameState.InMainMenu;
                break;


            case GameState.Win:
                level++;
                if (level > MAX_LEVEL)
                {
                    SceneManager.LoadScene("Victory");
                }
                else
                {
                    SceneManager.LoadScene("Level" + level);
                    _state = GameState.GameOpened;
                }
                
                break;
                
        }
    }

    public GameState getState()
    {
        return _state;
    }

}

public enum GameState
{
    InMainMenu,
    GameOpened,
    GameInProcess,
    Lose,
    Win
}