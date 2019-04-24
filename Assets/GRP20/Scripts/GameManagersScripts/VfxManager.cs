using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class VfxManager : MonoBehaviour
    {

        public ParticleSystem cutImpactFx;

        public void CutImpact(Vector3 _position)
        {
            cutImpactFx.transform.position = _position;
            cutImpactFx.Play();
        }
    }

}
