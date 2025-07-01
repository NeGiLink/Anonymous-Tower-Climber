using UnityEngine;

namespace MyAssets
{
    // プレイヤーの剣のアニメーションを管理するクラス
    public class SwordAnimator : MonoBehaviour
    {
        [SerializeField]
        private float               mRotateZ;

        [SerializeField]
        private float               mRotateSpeed;

        private bool                mAttackStart;

        [SerializeField]
        private GameObject          mSwordHandle;

        private PlayerSEManager     mSEManager;

        private void Awake()
        {
            mSEManager = GetComponent<PlayerSEManager>();
        }

        private void Start()
        {
            RotateReset();
        }
        
        private void RotateReset()
        {
            Vector3 rot = Vector3.zero;
            mSwordHandle.transform.localRotation = Quaternion.Euler(rot);
            mSwordHandle.SetActive(false);
            mAttackStart = false;
        }

        private void RotateStart()
        {
            Vector3 rot = Vector3.zero;
            mSwordHandle.transform.localRotation = Quaternion.Euler(rot);
            mSwordHandle.SetActive(true);
            mAttackStart = true;
        }

        private void Update()
        {
            if (mAttackStart)
            {
                Vector3 rot = mSwordHandle.transform.localRotation.eulerAngles;
                Vector3 goleRot = new Vector3(rot.x, rot.y, mRotateZ);
                Vector3 currntRot = Vector3.Lerp(rot, goleRot, mRotateSpeed * Time.deltaTime);
                mSwordHandle.transform.localRotation = Quaternion.Euler(currntRot);
                if(mSwordHandle.transform.localRotation.eulerAngles.z < 360.0f + mRotateZ)
                {
                    RotateReset();
                }
            }
            else
            {
                if (InputManager.GetKeyDown(KeyCode.eAttack))
                {
                    RotateStart();
                    mSEManager.OnPlay((int)PlayerSEManager.SEList_Player.eAttack);
                }
            }
        }
    }
}
