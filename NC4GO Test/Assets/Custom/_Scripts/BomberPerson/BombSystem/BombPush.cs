using Frttpc.Statics;
using UnityEngine;

namespace BomberPerson.BombSystem
{
    public class BombPush : MonoBehaviour
    {
        [SerializeField] private int speed;
        private GameObject lastPushed;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.layer == 7 && hit.gameObject != lastPushed)
            {
                Vector3 dir = -hit.normal.GetBiggestDir();

                Debug.DrawLine(hit.point - transform.position, -hit.normal * 5, Color.green, 5f);

                hit.gameObject.GetComponent<Rigidbody>().AddForce(speed * dir, ForceMode.Impulse);
                lastPushed = hit.gameObject;
            }
        }
    }
}
