using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfigSO playerConfigSO;
    [SerializeField] private KeyCode _leftMouseButton = KeyCode.Mouse0;
    public override void InstallBindings()
    {
        BindInputHandler();
        BindInputButtons();
        BindPlayerConfig();
    }

    private void BindInputHandler()
    {
        Container
            .Bind<IInputHandler>()
            .To<InputHandler>()
            .AsSingle();
    }

    private void BindInputButtons()
    {
        Container
            .Bind<IInput>()
            .WithId(InjectDataID.Horizontal)
            .To<InputReader>()
            .AsCached()
            .NonLazy();

        Container
            .Bind<KeyCode>()
            .WithId(InjectDataID.LeftMouseButton)
            .To<KeyCode>()
            .FromInstance(_leftMouseButton)
            .AsCached()
            .NonLazy();
    }

    private void BindPlayerConfig()
    {
        Container
            .Bind<PlayerConfigSO>()
            .FromInstance(playerConfigSO)
            .AsSingle();
    }

}

public static class InjectDataID 
{
    public const string Horizontal = "Horizontal";
    public const string LeftMouseButton = "LMB";
}