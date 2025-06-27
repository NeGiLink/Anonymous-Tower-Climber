using UnityEngine;

namespace MyAssets
{
    public class SpikyTrap : MonoBehaviour
    {
        private Transform mSpiky;

        private Vector3 mActiveSpokyPos;

        private bool mIsActiveSpiky;
        [SerializeField]
        private float mSpeed;

        private void Awake()
        {
            mSpiky = GetComponentInChildren<Transform>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mActiveSpokyPos = mSpiky.position + new Vector3(0, 1.0f,0);
        }

        // Update is called once per frame
        void Update()
        {
            if(!mIsActiveSpiky)
            {
                Ray2D ray = new Ray2D(transform.position + new Vector3(0.5f,0.0f,0.0f), Vector2.up);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 3.0f, LayerMask.GetMask("DynamicObject"));
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // PlayerがRayの先にいる場合、スパイクを表示
                    mIsActiveSpiky = true;
                }

                ray = new Ray2D(transform.position + new Vector3(-0.5f, 0.0f, 0.0f), Vector2.up);
                hit = Physics2D.Raycast(ray.origin, ray.direction, 3.0f, LayerMask.GetMask("DynamicObject"));
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // PlayerがRayの先にいる場合、スパイクを表示
                    mIsActiveSpiky = true;
                }
            }
            else
            {
                mSpiky.position = Vector3.Lerp(mSpiky.position, mActiveSpokyPos, Time.deltaTime * mSpeed);
            }
        }
    }
}
