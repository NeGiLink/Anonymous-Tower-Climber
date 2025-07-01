using UnityEngine;

namespace MyAssets
{
    public class LedgerBase<T> : ScriptableObject
    {
        [SerializeField]
        private T[] mValues;
        public T[] Values { get => mValues; }
        public T this[int i] { get => mValues[i]; }
        public int Count { get => mValues.Length; }
    }
}
