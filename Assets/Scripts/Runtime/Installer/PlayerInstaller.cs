using TopDos.Controls;
using TopDos.PlayerSpace;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealth _health;
    private ControlsHandler _controlsHandler;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromInstance(_health).AsSingle();
    }
}