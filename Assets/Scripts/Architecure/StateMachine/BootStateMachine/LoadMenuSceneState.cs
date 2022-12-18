using System;
using System.Threading.Tasks;
using Architecure.StateMachine.Base;
using Global.Progress.Data;
using UnityEngine.SceneManagement;
using Zenject;

namespace Architecure.StateMachine.BootStateMachine
{
    public class LoadMenuSceneState : IState
    {
        private const string SceneName = "MainMenu";

        public void Enter()
        {
            LoadMenuScene();
        }

        public void Exit()
        {
            
        }

        private async void LoadMenuScene()
        {
            await Task.Delay(UnityEngine.Random.Range(300,800));
            SceneManager.LoadScene(SceneName);
        }
    }
}