using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : Singleton<GameStateManager>
{
    private GameObject player;
    private GameObject gameOverCanvas;
    public int level = 0;

    public enum GameState
    {
        Running,
        Over
    }

    private GameState currentState = GameState.Running;

    public GameObject GameOverCanvas { get => gameOverCanvas; set => gameOverCanvas = value; }

    public void SetGameState(GameState state)
    {
        currentState = state;

        if (currentState == GameState.Over)
        {
            Movement movement = player.GetComponent<Movement>();
            movement.playerSprite.gameObject.SetActive(false);
            movement.enabled = false;
            player.GetComponent<Attack>().enabled = false;

            GameOverCanvas.GetComponent<CanvasGroup>().Show();
        }
    }

    public GameState GetGameState()
    {
        return currentState;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(level);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}
