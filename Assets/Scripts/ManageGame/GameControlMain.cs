using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Watermelon;

public class GameControlMain : MonoBehaviour
{
    public static GameControlMain Instance{get; private set;}
    [SerializeField]
    [Range(1, 10)]
    private int _level = 1;
    public int Level => _level;
    [SerializeField]
    private GameState _currentGameState;
    public GameState CurrentGameState => _currentGameState;
    [SerializeField]
    private PlayerBehaviour _playerBehaviour;
    [SerializeField]
    private MapGenerator _mapGenerator;
    [SerializeField]
    private TsunamiBehaviour _stunamiBehaviour;
    public UnityEvent UpgrageSpeedEvent;
    public UnityEvent StartPlayGame;

    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else{
            Instance = this;
            _currentGameState = GameState.Start;
        }
    }

    private void Start() {
        _mapGenerator = GetComponent<MapGenerator>();
        _mapGenerator.GenerateMap();
        GameUIControlMain.Instance.Initialise();
        SetGameState(GameState.Lobby);
        CameraController.SetMainTarget(_playerBehaviour.gameObject.transform);
    }

    public void SetGameState(GameState state)
    {
        if(_currentGameState == state) return;
        _currentGameState = state;
        GameUIControlMain.Instance.ChangeUI();
        ChangeMainCamera();
    }

    public void StartToPlay()
    {
        SetGameState(GameState.Start);
        StartCoroutine("PrepareTime");
    }

    IEnumerator PrepareTime()
    {
        yield return new WaitForSeconds(Constants.PrepareToPlayTime);
        SetGameState(GameState.Playing);
        StartPlayGame.Invoke();
        yield return null;
    }

    private void ChangeMainCamera()
    {
        switch (_currentGameState)
        {
            case GameState.Lobby:
                CameraController.EnableCamera(Watermelon.CameraType.Lobby);
                break;
            case GameState.Start:
                CameraController.EnableCamera(Watermelon.CameraType.Start);
                break;
            case GameState.Playing:
                CameraController.EnableCamera(Watermelon.CameraType.Main);
                break;
            case GameState.Victory:
            case GameState.GameOver:
                CameraController.EnableCamera(Watermelon.CameraType.GameOver);
                break;
        }
    }
    public float GetPlayerSpeed() => _playerBehaviour.PlayerInfo.MoveSpeed;

    public void UpgradePlayerSpeed()
    {
        _playerBehaviour.PlayerInfo.UpgradeMoveSpeed();
        UpgrageSpeedEvent.Invoke();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
