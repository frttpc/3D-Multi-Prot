using UnityEngine;
using TMPro;

namespace BomberPerson.UI
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bombCountText;
        [SerializeField] private TextMeshProUGUI healthCountText;
        [SerializeField] private TextMeshProUGUI rangeAmountText;
        [SerializeField] private TextMeshProUGUI speedAmountText;

        public static HUDManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void IncreaseBombCount()
        {
            int bombCount = short.Parse(bombCountText.text) + 1;
            bombCountText.text = bombCount.ToString();
        }

        public void IncreaseHealthCount()
        {
            int healthCount = short.Parse(healthCountText.text) + 1;
            healthCountText.text = healthCount.ToString();
        }

        public void IncreaseRangeAmount()
        {
            int rangeAmount = short.Parse(rangeAmountText.text) + 1;
            rangeAmountText.text = rangeAmount.ToString();
        }

        public void IncreaseSpeedAmount()
        {
            int speedAmount = short.Parse(speedAmountText.text) + 1;
            speedAmountText.text = speedAmount.ToString();
        }
    }
}