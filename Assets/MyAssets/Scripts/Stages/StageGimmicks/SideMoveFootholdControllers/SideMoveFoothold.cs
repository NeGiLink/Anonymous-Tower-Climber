using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class SideMoveFoothold : DynamicGameObject
    {
        private float mMoveSpeed; // 足場の移動速度

        private bool mIsReverse; // 足場の移動方向を反転するかどうか

        private Rigidbody2D mRigidbody2D; // 足場のRigidbody2Dコンポーネント

        private List<Rigidbody2D> mRidingObjects = new List<Rigidbody2D>(); // 足場に乗っているオブジェクトのリスト

        public void Initialize(float moveSpeed, bool isReverse)
        {
            mMoveSpeed = moveSpeed;
            mIsReverse = isReverse;
        }

        private void Awake()
        {
            // Rigidbody2Dコンポーネントを取得
            mRigidbody2D = GetComponent<Rigidbody2D>();
            if (mRigidbody2D == null)
            {
                Debug.LogError("Rigidbody2D component is missing on the SideMoveFoothold GameObject.");
            }
        }

        public override void Update()
        {
            base.Update();
        }

        private void FixedUpdate()
        {
            if (!IsTopOutViewport())
            {
                // 足場の移動処理
                MoveFoothold();

                RidingObjectUpdate();
            }
            else
            {
                mRigidbody2D.linearVelocity = Vector2.zero; // 足場が画面外に出たら速度をゼロにする
            }
        }

        private void MoveFoothold()
        {
            float speed = mMoveSpeed;
            speed *= Time.deltaTime; // 移動速度を時間で調整
            // 足場の移動方向を決定
            Vector2 moveDirection = mIsReverse ? Vector2.left : Vector2.right;
            // Rigidbody2Dを使用して足場を移動
            mRigidbody2D.linearVelocity = moveDirection * speed;
        }

        private void RidingObjectUpdate()
        {
            // 足場に乗っているオブジェクトの位置を更新
            foreach (Rigidbody2D ridingObject in mRidingObjects)
            {
                if (ridingObject != null)
                {
                    // 足場の移動に合わせてオブジェクトの位置を更新
                    ridingObject.position += mRigidbody2D.linearVelocity * Time.deltaTime;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // プレイヤーが足場に乗ったときの処理
                Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null && !mRidingObjects.Contains(playerRigidbody))
                {
                    mRidingObjects.Add(playerRigidbody);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // プレイヤーが足場から降りたときの処理
                Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null && mRidingObjects.Contains(playerRigidbody))
                {
                    mRidingObjects.Remove(playerRigidbody);
                }
            }
        }
    }
}
