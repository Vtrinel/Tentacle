using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class DeadTentacleCreator : TentacleCreator
    {

        public LineRenderer shadowLineTemplate;
        public LayerMask groundLayer;

        public override void TentacleCreation(float _startWidth, float _endWidth, Vector3 spawnPosition)
        {

            GameObject tentacle = new GameObject("tentacle");
            tentacle.transform.position = spawnPosition;
            LineRenderer line = tentacle.AddComponent<LineRenderer>(); //create line Renderer;
            line.material = lineMaterial;

            TentaclePointCreation(tentacle.transform);

            Tentacle t = new Tentacle(points, line);

            line.startWidth = _startWidth;
            line.endWidth = _endWidth;

            currentTentacle = t;
            t.UpdateTentacle();

            TentacleDead tentacleDead = tentacle.AddComponent<TentacleDead>();
            tentacleDead.tentacle = t;
            Rigidbody rb = tentacle.AddComponent<Rigidbody>();
            rb.useGravity = true;

            tentacle.AddComponent<DeadZoneY>();
        }

        public override void TentaclePointCreation(Transform _parent)
        {
            base.TentaclePointCreation(_parent);
        }
    }
}

