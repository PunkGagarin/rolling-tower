using gameSession.cards.UI;
using UnityEngine;
using Zenject;

public class CardChoosingUIInstaller : MonoInstaller {

    [SerializeField]
    private CardChoosingUI _cardChoosingUI;

    public override void InstallBindings() {

        Container.Bind<CardChoosingUI>()
            .FromInstance(_cardChoosingUI)
            .AsSingle();
    }
}