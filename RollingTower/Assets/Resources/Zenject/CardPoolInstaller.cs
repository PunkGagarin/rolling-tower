using gameSession.cards.Pool;
using Zenject;

public class CardPoolInstaller : MonoInstaller
{
    public override void InstallBindings() {

        Container.Bind<ICardPool>()
            .To<SelfCardPool>()
            .FromNew()
            .AsSingle();
    }
}