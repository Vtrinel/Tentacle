using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class DebugLoseZone : MonoBehaviour
    {

        public bool showDebug = true;

        private void OnDrawGizmos()
        {
            if (!showDebug) return;

            BoxCollider coll = GetComponent<BoxCollider>();

            Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
            Gizmos.DrawCube(transform.position + coll.center, coll.size);
            Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.9f);
            Gizmos.DrawWireCube(transform.position + coll.center, coll.size);
        }

        private void OnDrawGizmosSelected()
        {
            if (!showDebug) return;

            BoxCollider coll = GetComponent<BoxCollider>();

            Gizmos.color = new Color(Color.magenta.r, Color.magenta.g, Color.magenta.b, 0.5f);
            Gizmos.DrawCube(transform.position + coll.center, coll.size);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(transform.position + coll.center, coll.size);
        }
    }
}

