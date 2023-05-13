using System.Collections;
using System.Collections.Generic;
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
                Vector3 dir = -hit.normal;

                hit.gameObject.GetComponent<Rigidbody>().AddForce(speed * dir, ForceMode.Impulse);
                lastPushed = hit.gameObject;
            }
        }
    }
}
