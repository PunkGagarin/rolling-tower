using gameSession.cards;
using UnityEngine;
using Zenject;

public class CardManagerInstaller : MonoInstaller {

    [SerializeField]
    private CardChoosingManager _gameManager;


    public override void InstallBindings() {
        Container.Bind<CardChoosingManager>()
            .FromInstance(_gameManager)
            .AsSingle();
    }
}