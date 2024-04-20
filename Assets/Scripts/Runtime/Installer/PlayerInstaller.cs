using TopDos.Animations;
using TopDos.Controls;
using TopDos.PlayerSpace;
using TopDos.Weapons;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealth _health;
    private Weapon _weapon;
    [SerializeField] private ControlsHandler _controlsHandler;

    public override void InstallBindings()
    {
        _weapon = _player.GetComponentInChildren<Weapon>();

        Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
        Container.Bind<PlayerHealth>().FromInstance(_health).AsSingle();

        _controlsHandler.Init();
    }

    public void Initialize()
    {
        
    }
}