using TopDos.UI;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoInstaller, IInitializable
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private HealthBarPresenter _healthBarPresenter;
    
    public override void InstallBindings()
    {
        //_healthBarPresenter.Init();
    }

    public void Initialize()
    {
        //_enemySpawner.Init();
    }
}