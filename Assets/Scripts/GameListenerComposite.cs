using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameListenerComposite : MonoBehaviour,IGameStartListener,IGamePauseListener,IGameResumeListener,IGameFinishListener
{
    [Inject]
    private GameManager gameManager;
    [InjectLocal]
    private List<IGameListener> listeners=new();
    private void Start()
    {
        gameManager.AddListener(this);
    }
    private void OnDestroy()
    {
        gameManager.RemoveListener(this);
    }

    public void OnStartGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGameStartListener listener)
            {
                listener.OnStartGame();
            }
        }
    }
    public void OnPauseGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGamePauseListener listener)
            {
                listener.OnPauseGame();
            }
        }
    }
    public void OnResumeGame()
    {
        foreach (IGameListener it in listeners)
        {
            if (it is IGameResumeListener listener)
            {
                listener.OnResumeGame();
            }
        }
    }
    public void OnFinishGame()
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
