using UnityEngine;
using TMPro;

namespace Frttpc.UI
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countdownText;

        private void Start()
        {
            GameManager.Instance.OnCountdownStart += Show;
            GameManager.Instance.OnGameStart += Hide;

            Hide();
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnCountdownStart -= Show;
            GameManager.Instance.OnGameStart -= Hide;
        }

        private void Update()
        {
            countdownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownTimer()).ToString();
        }

        private void Show() => gameObject.SetActive(true);
        private void Hide() => gameObject.SetActive(false);
    }
}