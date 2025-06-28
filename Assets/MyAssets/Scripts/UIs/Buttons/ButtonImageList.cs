using UnityEngine;

namespace MyAssets
{
    public class ButtonImageList : MonoBehaviour
    {
        [SerializeField]
        private Sprite mNormal;
        public Sprite Normal => mNormal;
        [SerializeField]
        private Sprite mHover;
        public Sprite Hover => mHover;
    }
}
