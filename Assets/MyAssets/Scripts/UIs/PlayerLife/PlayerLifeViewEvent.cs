using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // プレイヤーのライフを表示するクラス
    public class PlayerLifeViewEvent : MonoBehaviour
    {
        private Text        mLifeText;

        private float       mChangeLifeTime = 2.0f;

        public event Action OnLifeChange;

        private void Awake()
        {
            mLifeText = GetComponentInChildren<Text>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            mLifeText.text = PlayerLifeManager.PastLife.ToString();
            PlayerLifeManager.LifeUpdate();
            OnLifeChange += ViewTextUpdate;
        }

        // Update is called once per frame
        private void Update()
        {
            if (mChangeLifeTime > 0.0f)
            {
                mChangeLifeTime -= Time.unscaledDeltaTime;
                if (mChangeLifeTime <= 0)
                {
                    mChangeLifeTime = 0.0f;
                    OnLifeChange?.Invoke();
                }
            }
        }

        private void ViewTextUpdate()
        {
            if(mLifeText.text != PlayerLifeManager.Life.ToString())
            {
                SystemSEManager.Instance.OnPlay((int)SystemSEManager.SEList_System.DecreaseLife);
            }
            mLifeText.text = PlayerLifeManager.Life.ToString();
        }
    }
}
