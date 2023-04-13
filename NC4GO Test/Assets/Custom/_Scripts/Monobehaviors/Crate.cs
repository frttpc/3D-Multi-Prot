using UnityEngine;

namespace Frttpc
{
    public class Crate : MonoBehaviour, IDamagable
    {
        public void Damage()
        {
            Destroy(gameObject);
        }
    }
}