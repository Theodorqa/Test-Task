using Resources.CodeBase.Main_Scene.Player;
using UnityEngine;
using Zenject;

namespace Resources.CodeBase.Main_Scene
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootComponent _shootComponent;
        [SerializeField] private InputComponent _inputComponent;

        public override void InstallBindings()
        {
            Container.Bind<MoveComponent>().FromInstance(_moveComponent);
            Container.Bind<ShootComponent>().FromInstance(_shootComponent);
            Container.Bind<InputComponent>().FromInstance(_inputComponent);
        }
    
    }
}
