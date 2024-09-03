using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameListener
{
}
public interface IGameStartListener : IGameListener
{
    void OnStartGame();
}
public interface IGamePauseListener : IGameListener
{
    void OnPauseGame();
}
public interface IGameResumeListener : IGameListener
{
    void OnResumeGame();
}
public interface IGameFinishListener : IGameListener
{
    void OnFinishGame();
}
