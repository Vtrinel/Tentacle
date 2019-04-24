using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class DeadZoneY : MonoBehaviour
    {

        public enum DestroyType
        {
            DestroyObject,
            DisableObject
        }

        public DestroyType destroyType = DestroyType.DestroyObject;

        public float destroyPos = -100;

        private void LateUpdate()
        {
            if (transform.position.y < destroyPos)
            {
                switch (destroyType)
                {
                    case DestroyType.DestroyObject:
                        Destroy(gameObject);
                        break;
                    case DestroyType.DisableObject:
                        gameObject.SetActive(false);
                        break;
                    default:
                        Destroy(gameObject);
                        break;
                }
                
            }
        }
    }
}
