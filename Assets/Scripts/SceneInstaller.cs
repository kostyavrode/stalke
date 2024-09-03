using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Character character;
    public override void InstallBindings()
    {
        this.Container.BindInterfacesTo<Character>().FromInstance(character).AsSingle();
    }
}
