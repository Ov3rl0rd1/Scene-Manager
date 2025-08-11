using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private GameState _gameState;
    [SerializeField] private LevelLoader _levelLoader;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<GameState>().FromInstance(_gameState).AsSingle();
        Container.Bind<LevelLoader>().FromInstance(_levelLoader).AsSingle();
    }
}