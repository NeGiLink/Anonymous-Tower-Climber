using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class PlayerLifeViewEvent : MonoBehaviour
    {
        private Text mLifeText;

        private float mChangeLifeTime = 2.0f;

        public event Action OnLifeChange;

        private void Awake()
        {
            mLifeText = GetComponentInChildren<Text>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
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
            mLifeText.text = PlayerLifeManager.Life.ToString();
        }
    }
}
