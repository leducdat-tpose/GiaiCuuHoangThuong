using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIControlMain : MonoBehaviour
{
    public static GameUIControlMain Instance{get; private set;}
    [SerializeField]
    private InfoUI _infoUI;
    [SerializeField]
    private PageGame _pageGame;
    [SerializeField]
    private LobbyUI _lobbyUI;
    [SerializeField]
    private GameOverUI _gameOverUI;
    [SerializeField]
    private VictoryUI _victoryUI;
    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
    public void Initialise()
    {
        _infoUI.Initialise();
        _pageGame.Initialise();
        _lobbyUI.Initialise();
        _gameOverUI.Initialise();
        _victoryUI.Initialise();
        ChangeUI();
    }
    public void ChangeUI()
    {
        _lobbyUI.gameObject.SetActive(false);
        _pageGame.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(false);
        _victoryUI.gameObject.SetActive(false);
        switch (GameControlMain.Instance.CurrentGameState)
        {
            case GameState.Lobby:
                _lobbyUI.gameObject.SetActive(true);
                break;
            case GameState.Playing:
                _pageGame.gameObject.SetActive(true);
                break;
            case GameState.GameOver:
                _gameOverUI.gameObject.SetActive(true);
                break;
            case GameState.Victory:
                _victoryUI.gameObject.SetActive(true);
                break;
        }
    }
}
