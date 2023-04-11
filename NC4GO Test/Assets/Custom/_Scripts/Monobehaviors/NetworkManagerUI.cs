using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

namespace Frttpc
{
    public class NetworkManagerUI : MonoBehaviour
    {
        [SerializeField] private Button hostButton;
        [SerializeField] private Button clientButton;

        [SerializeField] private TextMeshProUGUI statusText;

        public static NetworkManagerUI Instance;

        private void Awake()
        {
            Instance = this;

            hostButton.onClick.AddListener(() => {
                NetworkManager.Singleton.StartHost();
                statusText.text = "Host";
                DisableButtons();
            });
            
            clientButton.onClick.AddListener(() => {
                NetworkManager.Singleton.StartClient();
                statusText.text = "Client";
                DisableButtons();
            });
        }

        private void DisableButtons()
        {
            hostButton.interactable = false;
            clientButton.interactable = false;
        }
    }
}
