using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScriptableObjects.Base;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using Architecure.Services.Audio;

public class PlayAudioLoaderService : IDisposable, IPlayAudioLoaderService
{
    private const string Label = "PlayModeSounds";
    [Inject]
    private List<AssetReference> _sounds;
    [Inject]
    private SignalBus _signalBus;

    private AsyncOperationHandle<IList<Sound>> handle;

    public void Dispose()
    {
        Addressables.Release(handle);
    }

    public async Task Load()
    {
        handle = Addressables.LoadAssetsAsync<Sound>(Label, null);
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            List<Sound> result = handle.Result.ToList();
            _signalBus.Fire<SignalPlaySoundsLoaded>(new SignalPlaySoundsLoaded() {Sounds = result});
        }
    }
}
