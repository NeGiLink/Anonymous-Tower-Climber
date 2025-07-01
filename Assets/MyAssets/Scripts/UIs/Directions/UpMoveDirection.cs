using UnityEngine;

namespace MyAssets
{
    // ã•ûŒü‚ÉˆÚ“®‚·‚éUI—v‘f‚ğŠÇ—‚·‚éƒNƒ‰ƒX
    public class UpMoveDirection : MonoBehaviour
    {
        private RectTransform   mRectTransform;

        private float           mDestroyDelay = 2.5f;

        private float           mMoveSpeed = 1000.0f;

        public void SetMoveSpeed(float speed)
        {
            mMoveSpeed = speed;
        }


        private float mMoveCooltime = 0.0f;

        public void SetMoveCooltime(float cooltime)
        {
            mMoveCooltime = cooltime;
        }

        private void Awake()
        {
            mRectTransform = GetComponent<RectTransform>();
            if (mRectTransform == null)
            {
                Debug.LogError("UpMoveDirection requires a RectTransform component.");
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            Destroy(gameObject, mDestroyDelay);
        }

        // Update is called once per frame
        private void Update()
        {
            mMoveCooltime -= Time.unscaledDeltaTime;
            if (mMoveCooltime > 0.0f) { return; }
            Vector2 position = mRectTransform.anchoredPosition;
            position.y += mMoveSpeed * Time.unscaledDeltaTime;
            mRectTransform.anchoredPosition = position;

            if (mRectTransform.anchoredPosition.y > Screen.height)
            {
                Destroy(gameObject);
            }
        }
    }
}
