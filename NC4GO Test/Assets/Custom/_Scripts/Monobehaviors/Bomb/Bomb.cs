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
        [SerializeField] private float countdown = 3;
        private int range = 1;

        private SphereCollider sphereCollider;

        public event Action OnDetonate;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();    
        }

        private void Start()
        {
            OnDetonate += Explode;
        }

        private void Update()
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0f)
                OnDetonate?.Invoke();
        }

        private void Explode()
        {
            ExplosionDir();
            Destroy(gameObject);
        }

        private void ExplosionDir()
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

                Destroy(line.gameObject, 2f);

                rayDir.Rotate(Vector3.up, 90f);
            }
        }

        public void IncreaseRange() => range++;
    }
}