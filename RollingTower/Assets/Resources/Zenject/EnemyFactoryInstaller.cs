using gameSession.battle;
using Zenject;

public class EnemyFactoryInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<EnemyFactory>()
            .FromNew()
            .AsSingle();
    }
}