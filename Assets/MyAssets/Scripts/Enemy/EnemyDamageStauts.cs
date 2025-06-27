using UnityEngine;

namespace MyAssets
{
    public class EnemyDamageStauts : MonoBehaviour
    {
        [SerializeField]
        private float mKnockbackForce;

        public float KnockbackForce => mKnockbackForce;
    }
}
