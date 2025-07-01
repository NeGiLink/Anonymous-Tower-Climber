using UnityEngine;

namespace MyAssets
{
    //下方向から上方向に移動する敵キャラクターの移動クラス
    public class AreaMomementer : MonoBehaviour
    {

        private TiledArea   mTiledArea;

        [SerializeField]
        private Transform   mFace;

        private void Awake()
        {
            mTiledArea = GetComponentInChildren<TiledArea>();
        }

        private void Update()
        {
            float sizeY = mTiledArea.SpriteRenderer.size.y;
            sizeY /= 2.0f;
            mFace.position = new Vector3(mFace.position.x, mTiledArea.transform.position.y + sizeY, mFace.position.z);
        }
    }
}
