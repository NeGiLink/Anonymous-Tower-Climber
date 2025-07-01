using UnityEngine;

namespace MyAssets
{
    // スパイクトラップのクラス
    public class SpikyTrap : MonoBehaviour
    {
        private Transform     mSpiky;

        private Vector3       mActiveSpokyPos;

        private bool          mIsActiveSpiky;
        [SerializeField]
        private float         mSpeed;

        private BoxCollider2D mBoxCollider2D;

        private void Awake()
        {
            mSpiky = GetComponentInChildren<Transform>();
            mBoxCollider2D = GetComponentInChildren<BoxCollider2D>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mActiveSpokyPos = mSpiky.position + new Vector3(0, 1.0f,0);
            mBoxCollider2D.enabled = false; // 初期状態ではコライダーを無効化
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
                    mBoxCollider2D.enabled = true; // コライダーを有効化
                }

                ray = new Ray2D(transform.position + new Vector3(-0.5f, 0.0f, 0.0f), Vector2.up);
                hit = Physics2D.Raycast(ray.origin, ray.direction, 3.0f, LayerMask.GetMask("DynamicObject"));
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // PlayerがRayの先にいる場合、スパイクを表示
                    mIsActiveSpiky = true;
                    mBoxCollider2D.enabled = true; // コライダーを有効化
                }
            }
            else
            {
                mSpiky.position = Vector3.Lerp(mSpiky.position, mActiveSpokyPos, Time.deltaTime * mSpeed);
            }
        }
    }
}
