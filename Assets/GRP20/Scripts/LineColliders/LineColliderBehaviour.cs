using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class LineColliderBehaviour : MonoBehaviour
    {
        public LineCollider lineCollider;
        public float colliderWidth = 1;
        public float colliderHeight = 1;


        void Start()
        {
            //Get lineCollider
        }


        void Update()
        {
            AdjustCollider(lineCollider.collider, lineCollider.startPosition.position, lineCollider.endPosition.position);
        }

        void AdjustCollider(BoxCollider lineCollider, Vector3 startPoint, Vector3 endPoint)
        {
            //SHAPE

            float lineLength = Vector3.Distance(startPoint, endPoint); // get the length
            lineCollider.size = new Vector3(colliderWidth, colliderHeight, lineLength); // size of collider is set where Z is length of line

            //POSITION
            Vector3 midPoint = (startPoint + endPoint) / 2; // get midPoint
            lineCollider.transform.position = midPoint; // set collider to the midPoint

            //ROTATION
            Quaternion rotation = Quaternion.LookRotation(startPoint - endPoint, Vector3.forward); //get direction of rotation
            lineCollider.transform.rotation = rotation; //apply rotation
        }
    }
}

