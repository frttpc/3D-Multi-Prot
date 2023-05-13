using UnityEngine;
using Frttpc.Interfaces;
using Frttpc.SOs;

namespace BomberPerson.BombSystem
{
    public class Bomb : MonoBehaviour, IDamagable
    {
        [SerializeField] private Transform rayDir;
        [SerializeField] private LineRenderer explosionLine;
        [SerializeField] private BoxCollider boxCollider;

        [Header("Push")]
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float speed;
        private bool pushed = false;
        private Vector2 dir;

        [Header("Explosion")]
        [SerializeField] private GameEvent OnExplodeEvent;
        [SerializeField] private float countdown = 3;
        [SerializeField] private float explosionDuration;
        private float range;
        private bool exploded = false;

        private void Update()
        {
            countdown -= Time.deltaTime;

            if (pushed)
            {
                transform.Translate(speed * Time.deltaTime * dir);
            }

            if (countdown <= 0f)
            {
                Boom();
            }
        }

        public void Damage()
        {
            if(!exploded)
                Boom();
        }

        public void Boom()
        {
            exploded = true;
            OnExplodeEvent.Raise();
            Explode();
            Destroy(gameObject);
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

                Destroy(line.gameObject, explosionDuration);

                rayDir.Rotate(Vector3.up, 90f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            boxCollider.isTrigger = false;
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.layer == 6)
        //    {
        //        print("layer");

        //        dir = -collision.GetContact(0).normal;
        //        pushed = true;
        //    }
        //    //else if (pushed)
        //    //{
        //    //    pushed = false;
        //    //}
        //}

        public void SetRange(float newRange) => range = newRange;
    }
}