using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<IGameListener> listeners;
    public void AddListener(IGameListener listener)
    {
        this.listeners.Add(listener);
    }
    public void RemoveListener(IGameListener listener)
    {
        this.listeners.Remove(listener);
    }
    public void StartGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGameStartListener listener)
            {
                listener.OnStartGame();
            }
        }
    }
    public void PauseGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGamePauseListener listener)
            {
                listener.OnPauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGameResumeListener listener)
            {
                listener.OnResumeGame();
            }
        }
    }
    public void FinishGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGameFinishListener listener)
            {
                listener.OnFinishGame();
            }
        }
    }
}
