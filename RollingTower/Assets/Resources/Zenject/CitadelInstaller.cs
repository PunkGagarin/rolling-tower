using entities.player.citadels;
using UnityEngine;
using Zenject;

public class CitadelInstaller : MonoInstaller {

    [SerializeField]
    private Citadel _citadel;

    [SerializeField]
    private Transform _spawnPosition;


    public override void InstallBindings() {
        var citadelInstance =
            Container.InstantiatePrefabForComponent<Citadel>(_citadel, _spawnPosition.position, Quaternion.identity,
                null);

        Container.Bind<Citadel>()
            .FromInstance(citadelInstance)
            .AsSingle()
            .NonLazy();
        
    }
}