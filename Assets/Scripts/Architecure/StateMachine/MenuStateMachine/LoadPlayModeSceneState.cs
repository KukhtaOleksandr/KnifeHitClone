using Architecure.StateMachine.Base;
using UnityEngine.SceneManagement;

namespace Architecure.StateMachine.MenuStateMachine
{
    public class LoadPlayModeSceneState : IState
    {
        private const string SceneName = "PlayScene";
        public void Enter()
        {
            SceneManager.LoadScene(SceneName);
        }

        public void Exit()
        {
            
        }
    }
}