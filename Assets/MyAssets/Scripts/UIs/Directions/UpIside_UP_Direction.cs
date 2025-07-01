using UnityEngine;

namespace MyAssets
{
    // 上方向に移動するイベントUIオブジェクト
    public class UpIside_UP_Direction : EventUIObject
    {
        private RectTransform   mRectTransform;

        private float           mGoalYPosition = 0f;

        private Timer           mMoveCoolTimer = new Timer();
        [SerializeField]
        private float           mMoveSpeed = 1.0f;
        public void SetMoveSpeed(float speed)
        {
            mMoveSpeed = speed;
        }

        private void Awake()
        {
            mRectTransform = GetComponent<RectTransform>();
            if (mRectTransform == null)
            {
                Debug.LogError("RectTransform component is missing on this GameObject.");
            }
        }
        
        private void Start()
        {
            mGoalYPosition = mRectTransform.anchoredPosition.y;

            Vector2 anchoredPosition = mRectTransform.anchoredPosition;
            float youtsidePos = Screen.height * 2f;
            anchoredPosition.y = youtsidePos;
            mRectTransform.anchoredPosition = anchoredPosition;


        }

        // Update is called once per frame
        private void Update()
        {
            mMoveCoolTimer.Update(Time.unscaledDeltaTime);

            if(mMoveCoolTimer.IsEnd())
            {
                Vector2 anchoredPosition = mRectTransform.anchoredPosition;
                anchoredPosition.y = Mathf.Lerp(anchoredPosition.y, mGoalYPosition, Time.unscaledDeltaTime * mMoveSpeed);
                mRectTransform.anchoredPosition = anchoredPosition;
                if (Mathf.Abs((int)anchoredPosition.y - (int)mGoalYPosition) < 0.01f)
                {
                    mIsEventEnd = true;
                }
            }
        }
    }
}
