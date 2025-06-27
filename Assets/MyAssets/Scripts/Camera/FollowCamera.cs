using UnityEngine;

namespace MyAssets
{
    public class FollowCamera : MonoBehaviour
    {
        private Transform mTarget;

        private float mMoveRatio;

        private float mMinPositionY;
        private float mMaxPositionY;


        public void SetTarget(Transform target)
        {
            mTarget = target;
        }

        private void Awake()
        {
            mTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            mMinPositionY = transform.position.y;
        }

        // Update is called once per frame
        private void Update()
        {
            if(mTarget == null) { return; }
            Vector3 targetPos = mTarget.position;

            if(mTarget.position.y  < mMinPositionY)
            {
                transform.position = new Vector3(transform.position.x,mMinPositionY, transform.position.z);
            }
            else if (mTarget.position.y > transform.position.y || mTarget.position.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, targetPos.y, transform.position.z);
            }
            
        }
    }
}
