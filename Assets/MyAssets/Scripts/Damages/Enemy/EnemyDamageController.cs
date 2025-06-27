using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class EnemyDamageController : MonoBehaviour
    {

        private Rigidbody2D mRigidbody2D;

        private Collider2D  mCollider2D;

        private float mDestroyDelay = 5f;

        private List<MonoBehaviour> mMonoBehaviour = new List<MonoBehaviour>();


        private bool mIsDead = false;

        //ダメージでカラーを変更した時のVector4
        private Vector4 mDamageColor = new Vector4(1f, 0.5f, 0.5f, 1f);

        private Vector4 mNormalColor;

        private SpriteRenderer mSpriteRenderer;

        private float mDamageColorChangeDuration = 0.2f;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCollider2D = GetComponent<Collider2D>();

            MonoBehaviour[] mono = GetComponents<MonoBehaviour>();
            for (int i = 0; i < mono.Length; i++)
            {
                if (mono[i] != this)
                {
                    mMonoBehaviour.Add(mono[i]);
                }
            }
        }

        private void Start()
        {
            // Get the normal color from the SpriteRenderer
            mSpriteRenderer = GetComponent<SpriteRenderer>();
            if (mSpriteRenderer != null)
            {
                mNormalColor = mSpriteRenderer.color;
            }
        }

        public void OnDamage(Vector2 force)
        {
            if (mIsDead) { return; }
            mRigidbody2D.AddForce(force, ForceMode2D.Impulse);
            mCollider2D.isTrigger = true;
            // Change the color to indicate damage
            if (mSpriteRenderer != null)
            {
                mSpriteRenderer.color = mDamageColor;
            }
            // Disable other MonoBehaviours
            for (int i = 0; i < mMonoBehaviour.Count; i++)
            {
                if (mMonoBehaviour[i] != null)
                {
                    mMonoBehaviour[i].enabled = false;
                }
            }
            // Destroy the enemy after a delay
            Destroy(gameObject, mDestroyDelay);
            mIsDead = true;
        }

        private void Update()
        {
            if(!mIsDead) { return; }
            mDamageColorChangeDuration -= Time.deltaTime;
            if (mDamageColorChangeDuration <= 0f)
            {
                // Reset the color to normal after the damage effect
                if (mSpriteRenderer != null)
                {
                    mSpriteRenderer.color = mNormalColor;
                }
                mDamageColorChangeDuration = 0.5f; // Reset the duration for next use
            }
            else if (mSpriteRenderer != null)
            {
                // Change the color to indicate damage
                mSpriteRenderer.color = Color.Lerp(mNormalColor, mDamageColor, 1 - (mDamageColorChangeDuration / 0.2f));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (mIsDead) { return; }
            //ダメージを与える処理
            //当たった相手に処理を行う
            if (collision.TryGetComponent<PlayerDamageController>(out var damager))
            {
                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
                knockbackDirection += Vector2.up;
                damager.OnDamage(knockbackDirection);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(mIsDead) { return; }
            //ダメージを与える処理
            //当たった相手に処理を行う
            if (collision.collider.TryGetComponent<PlayerDamageController>(out var damager))
            {
                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
                knockbackDirection += Vector2.up;
                damager.OnDamage(knockbackDirection);
            }
        }
    }
}
