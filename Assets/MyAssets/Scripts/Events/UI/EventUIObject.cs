using UnityEngine;

namespace MyAssets
{
    // イベントUIオブジェクトの基底クラス
    public class EventUIObject : MonoBehaviour
    {
        protected bool mIsEventEnd;

        public bool IsEventEnd => mIsEventEnd;
    }
}
