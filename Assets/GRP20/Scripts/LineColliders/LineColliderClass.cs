using UnityEngine;

namespace GRP20
{
    [System.Serializable]
    public class LineCollider
    {
        public BoxCollider collider; //le box collider
        public Transform startPosition, endPosition;
    }
}

