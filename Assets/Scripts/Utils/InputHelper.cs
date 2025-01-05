using UnityEngine;

namespace Utilities
{
    public static class InputHelper
    {
        public static Vector3 GetMouseWorldPositionOnPlane()
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldPosition = ray.GetPoint(distance);
                return worldPosition;
            }

            return Vector3.zero;
        }

    }
}