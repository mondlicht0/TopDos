using TopDos.Controls;
using TopDos.Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    private ControlsHandler _controlsHandler;

    public override void InstallBindings()
    {
        //Player playerInstance = Container.InstantiatePrefabForComponent<Player>(_player);
    }
}