using Architecure.StateMachine.Base;
using UnityEngine.SceneManagement;

namespace Architecure.StateMachine.PlayModeStateMachine
{
    public class LoadMenuSceneState : IState
    {
        private const string MenuScene = "MainMenu";
        public void Enter()
        {
            SceneManager.LoadScene(MenuScene);
        }

        public void Exit()
        {
            
        }
    }
}