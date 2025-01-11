using UnityEngine;

namespace Hero
{
    public class Cam : MonoBehaviour
    {
        ObjectFader objectFader;

        void Update()
        {
            Player player = FindFirstObjectByType<Player>();
            if (player != null)
            {
                Vector3 dir = player.transform.position - transform.position;
                Ray ray = new Ray(transform.position, dir);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == null)
                    {
                        return;
                    }

                    if (hit.collider.gameObject.GetComponent<Player>())
                    {
                        if (objectFader != null)
                        {
                            objectFader.doFade = false;
                        }
                    }
                    else
                    {
                        objectFader = hit.collider.GetComponent<ObjectFader>();
                        if (objectFader != null)
                        {
                            objectFader.doFade = true;
                        }

                    }
                }
            }
        }
    }
}