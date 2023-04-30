using System.Collections;
using System;
using UnityEngine;
using Frttpc.Statics;

namespace Frttpc
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Transform rayDir;
        [SerializeField] private LineRenderer explosionLine;

        [Header("Explosion")]
        [SerializeField] private GameEvent OnExplodeEvent;
        [SerializeField] private float countdown = 3;
        [SerializeField] private float duration;
        private int range = 1;


        private void Update()
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0f)
            {
                OnExplodeEvent.Raise();
                Explode();
                Destroy(gameObject);
            }
        }

        private void Explode()
        {
            for (int i = 0; i < 4; i++)
            {
                Physics.BoxCast(transform.position, new Vector3(0.25f, 0, 0.25f), rayDir.forward, out RaycastHit raycastHit, Quaternion.identity, range);

                LineRenderer line = Instantiate(explosionLine, transform.position, Quaternion.identity);

                if (raycastHit.collider != null)
                {
                    if (raycastHit.collider.TryGetComponent(out IDamagable damagable))
                    {
                        damagable.Damage();
                    }

                    line.SetPosition(1, raycastHit.point - transform.position);
                }
                else
                {
                    line.SetPosition(1, rayDir.forward * range);
                }

                Destroy(line.gameObject, duration);

                rayDir.Rotate(Vector3.up, 90f);
            }
        }

        public void SetRange(int newRange) => range = newRange;
    }
}