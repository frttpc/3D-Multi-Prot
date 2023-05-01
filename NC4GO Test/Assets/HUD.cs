using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Frttpc
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bombText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI rangeText;
        [SerializeField] private TextMeshProUGUI speedText;
    }
}