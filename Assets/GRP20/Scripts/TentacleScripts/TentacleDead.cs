using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleDead : MonoBehaviour
    {
        public Tentacle tentacle;
        public TentacleShadow tentacleShadow;

        private void Start()
        {
            
        }

        void Update()
        {
            tentacle.UpdateTentacle();
        }
    }
}

