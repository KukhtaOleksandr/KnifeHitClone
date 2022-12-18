using Architecure.Services.Audio;
using Architecure.StateMachine.Base;
using Zenject;
using Global.Services.Settings;
using Knife;

namespace Global
{
    public class GlobalSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<SignalChangedState>();
            Container.DeclareSignal<SignalPlaySoundsLoaded>();
            Container.DeclareSignal<SignalSoundsStateChanged>();
            Container.DeclareSignal<SignalSoundsToggleChanged>();
            Container.DeclareSignal<SignalKnifeThrow>();
        }
    }
}