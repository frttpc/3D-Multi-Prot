using UnityEngine;
using UnityEngine.UI;

namespace Frttpc
{
    public class GameOverScreen : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.OnGameOver += Show;

            Hide();
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameOver -= Show;
        }

        public void WantSceneRestart() => SceneManager.Instance.OpenGameScene();
        public void WantMainMenuReturn() => SceneManager.Instance.OpenMainMenuScene();

        private void Show() => gameObject.SetActive(true);
        private void Hide() => gameObject.SetActive(false);
    }
}