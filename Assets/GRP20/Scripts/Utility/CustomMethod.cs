using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public static class CustomMethod
    {
        /// <summary>
        /// Permet d'obtenir l'épaisseur d'un point sur un lineRenderer
        /// </summary>
        /// <param name="_pointIndex"></param>
        /// <param name="_lineRenderer"></param>
        /// <returns></returns>
        public static float GetLineWidthAtPoint(int _pointIndex, LineRenderer _lineRenderer)
        {
            float width = 0;

            Vector3 endPoint = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
            Vector3 startPoint = _lineRenderer.GetPosition(0);
            Vector3 targetPoint = _lineRenderer.GetPosition(_pointIndex);

            float distance = Vector2.Distance(startPoint, endPoint);
            float targetDistance = Vector2.Distance(startPoint, targetPoint);

            float curveTargetValue = targetDistance / distance;

            width = _lineRenderer.widthCurve.Evaluate(curveTargetValue);

            return width;
        }

        public static bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
        {
            bool equal = true;

            if (Mathf.Abs(v1.x - v2.x) > precision) equal = false;
            if (Mathf.Abs(v1.y - v2.y) > precision) equal = false;
            if (Mathf.Abs(v1.z - v2.z) > precision) equal = false;

            return equal;
        }

        public static bool AlmostEqual2D(Vector2 v1, Vector2 v2, float precision)
        {
            bool equal = true;

            if (Mathf.Abs(v1.x - v2.x) > precision) equal = false;
            if (Mathf.Abs(v1.y - v2.y) > precision) equal = false;

            return equal;
        }

        public enum Axis
        {
            X,
            Y,
            Z
        }

        public static bool AlmostEqualOnOneAxis(Vector3 v1, Vector3 v2, float precision, Axis axis)
        {
            bool equal = true;

            switch (axis)
            {
                case Axis.X:
                    if (Mathf.Abs(v1.x - v2.x) > precision) equal = false;
                    break;
                case Axis.Y:
                    if (Mathf.Abs(v1.y - v2.y) > precision) equal = false;
                    break;
                case Axis.Z:
                    if (Mathf.Abs(v1.z - v2.z) > precision) equal = false;
                    break;
                default:
                    if (Mathf.Abs(v1.x - v2.x) > precision) equal = false;
                    break;
            }

            return equal;
        }

        public static int LayerMaskToLayer(LayerMask layerMask)
        {
            int layerNumber = 0;
            int layer = layerMask.value;

            while (layer > 0)
            {
                layer = layer >> 1;
                layerNumber++;
            }

            return layerNumber - 1;
        }

    }
}

