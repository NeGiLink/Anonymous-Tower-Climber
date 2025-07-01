using UnityEngine;

namespace MyAssets
{
    //下方向から上方向に移動してくる敵のエリア部分の処理をするクラス
    public class TiledArea : MonoBehaviour
    {
        private SpriteRenderer  mSpriteRenderer;
        public SpriteRenderer   SpriteRenderer => mSpriteRenderer;

        [SerializeField]
        private float           mSpeed;

        private void Awake()
        {
            mSpriteRenderer = GetComponent<SpriteRenderer>();
            if (mSpriteRenderer == null)
            {
                Debug.LogError("TiledArea requires a SpriteRenderer component.");
            }
        }

        private　void Update()
        {
            float y = mSpriteRenderer.size.y;
            y += mSpeed * Time.deltaTime;
            mSpriteRenderer.size = new Vector2(mSpriteRenderer.size.x, y);
        }
    }
}
