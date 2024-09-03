using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Character character;
    [SerializeField] private GameManager gameManager;
    public override void InstallBindings()
    {
        this.Container.BindInterfacesTo<Character>().FromInstance(character).AsSingle();
        this.Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
    }
}
