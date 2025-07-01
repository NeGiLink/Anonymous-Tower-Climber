using UnityEngine;

namespace MyAssets
{
    //���������������Ɉړ����Ă���G�̃G���A�����̏���������N���X
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

        private�@void Update()
        {
            float y = mSpriteRenderer.size.y;
            y += mSpeed * Time.deltaTime;
            mSpriteRenderer.size = new Vector2(mSpriteRenderer.size.x, y);
        }
    }
}
