using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Lobby,
    Start,
    Playing,
    GameOver
}

public static class Constants
{
    public static readonly string PlayerTag = "Player";
}
