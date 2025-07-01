using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    // プレイヤーキャラクターのダメージを管理するクラス
    public class PlayerDamageController : MonoBehaviour
    {

        private Rigidbody2D         mRigidbody2D;

        private Collider2D          mCollider2D;

        private float               mDestroyDelay = 5f;

        private List<MonoBehaviour> mMonoBehaviour = new List<MonoBehaviour>();

        private bool                mDeath;


        private PlayerSEManager     mSEManager;

        public bool                 Death => mDeath;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCollider2D = GetComponent<Collider2D>();
            mSEManager = GetComponent<PlayerSEManager>();

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
            mDeath = false;
        }

        public void OnDamage(Vector2 force)
        {
            if (mDeath) { return; }
            mRigidbody2D.AddForce(force, ForceMode2D.Impulse);
            mCollider2D.isTrigger = true;
            //このクラス以外のMonoBehaviourを無効化
            for (int i = 0; i < mMonoBehaviour.Count; i++)
            {
                if (mMonoBehaviour[i] != null)
                {
                    mMonoBehaviour[i].enabled = false;
                }
            }
            //プレイヤーを破壊する
            Destroy(gameObject, mDestroyDelay);
            //カメラのターゲットをnullに設定
            FollowCamera followCamera = Camera.main.GetComponent<FollowCamera>();
            if (followCamera != null)
            {
                followCamera.SetTarget(null);
            }
            GameResultManager.SetGameResult(GameResult.eLose);
            GameActionSceneManager gameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
            gameActionSceneManager.RunOverEvent();
            PlayerLifeManager.DecreaseLife();
            mDeath = true;
            mSEManager.OnPlay((int)PlayerSEManager.SEList_Player.eDamage);
        }
    }
}
