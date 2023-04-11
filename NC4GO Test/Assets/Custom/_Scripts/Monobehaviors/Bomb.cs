using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Frttpc
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int countdownTime = 3;
        private int range = 1;

        public event Action OnDetonate;

        private void Start()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(countdownTime);
            OnDetonate?.Invoke();
            Destroy(gameObject);
        }

        public void SetRange(int newRange) => range = newRange;
    }
}