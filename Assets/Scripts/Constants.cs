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
    public static readonly string AnimalTag = "Animal";

    public static readonly float IndexMultiplyWithSpeed = 10f;

    #region Tsunami
    public static readonly float TsunamiTimet0 = 15f; 
    public static readonly float TsunamiTimet1 = 40f; 
    public static readonly float TsunamiTimet2 = 25f; 
    public static readonly float TsunamSpeedv1 = 10f;
    public static readonly float TsunamSpeedv2 = 40f;
    #endregion
}
