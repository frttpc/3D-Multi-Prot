using System.Collections;
using System;
using UnityEngine;
using Frttpc.Statics;

namespace Frttpc
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Transform rayDir;

        [SerializeField] private int countdownTime = 3;
        private int range = 1;

        public event Action OnDetonate;

        private void Start()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            yield return Yielders.Get(countdownTime);
            OnDetonate?.Invoke();
            Explosion();
            Destroy(gameObject);
        }

        private void Explosion()
        {
            for (int i = 0; i < 4; i++)
            {
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, rayDir.forward, range);
                rayDir.Rotate(Vector3.up, 90f);

                Debug.DrawRay(transform.position, rayDir.forward, Color.red, 5);
            }
        }

        public void IncreaseRange() => range++;
    }
}