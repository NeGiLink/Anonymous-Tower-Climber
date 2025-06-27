using UnityEngine;

namespace MyAssets
{
    
    public class DynamicGameObject : MonoBehaviour
    {
        protected Vector3 mViewportPos;

        protected float mWidth;

        protected float mHeight;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public virtual void Start()
        {
            mWidth = 0.0f;
            mHeight = 0.0f;
        }

        // Update is called once per frame
        public virtual void Update()
        {
            mViewportPos = Camera.main.WorldToViewportPoint(transform.position);
        }

        public bool IsOutViewport()
        {
            return mViewportPos.x < 0 || mViewportPos.x > 1 || mViewportPos.y < 0 || mViewportPos.y > 1;
        }

        public bool IsSideOutViewport()
        {
            return mViewportPos.x < 0 || mViewportPos.x > 1;
        }

        public bool IsLeftOutViewport()
        {
            return mViewportPos.x < 0;
        }

        public bool IsRightOutViewport()
        {
            return mViewportPos.x > 1;
        }

        public bool IsTopOutViewport()
        {
            return mViewportPos.y > 1;
        }

        public bool IsBottomOutViewport()
        {
            return mViewportPos.y < 0;
        }
    }
}
