using UnityEngine;

namespace MyAssets
{
    //スプライト画像エフェクトの管理クラス
    public class FXController : MonoBehaviour
    {
        private Animator mAnimator;

        private void Awake()
        {
            mAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(EndCheck())
            {
                Destroy(gameObject);
            }
        }

        private bool EndCheck()
        {
            return mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
        }
    }
}
