using UnityEngine;

namespace Utilities
{
    public static class InputHelper
    {
        public static Vector3 GetMouseWorldPositionWithRaycast()
        {
            // Tạo mặt phẳng Y = 0
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                return hitInfo.point;
            }

            return Vector3.zero;
        }

    }
}