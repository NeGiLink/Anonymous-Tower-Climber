using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class SideMoveFootholdController : MonoBehaviour
    {

        [SerializeField]
        private SideMoveFoothold mFoothold;

        private List<SideMoveFoothold> mFootholds = new List<SideMoveFoothold>();

        [SerializeField]
        private float mFootholdcolumnCount;

        [SerializeField]
        private float mFootholdcolumnInterval;

        [SerializeField]
        private float mFootholdStartPosition;

        [SerializeField]
        private float mFootholdSpeed;

        [SerializeField]
        private bool mFootholdDirection;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            for(int i = 0; i < mFootholdcolumnCount; i++)
            {
                // Instantiate a new foothold
                SideMoveFoothold newFoothold = Instantiate(mFoothold, transform);
                // Set the position of the foothold based on the index and interval
                newFoothold.transform.localPosition = new Vector3(i * mFootholdcolumnInterval, 0, 0);
                // Initialize the foothold with speed and direction
                newFoothold.Initialize(mFootholdSpeed, mFootholdDirection); // Example values
                // Add the foothold to the list
                mFootholds.Add(newFoothold);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            for(int i = 0; i < mFootholds.Count; i++)
            {
                if(mFootholdDirection)
                {
                    // Update each foothold
                    if (mFootholds[i].IsLeftOutViewport())
                    {
                        mFootholds[i].transform.localPosition = new Vector3(mFootholdStartPosition, 0, 0);
                    }
                }
                else
                {
                    // Update each foothold
                    if (mFootholds[i].IsRightOutViewport())
                    {
                        mFootholds[i].transform.localPosition = new Vector3(mFootholdStartPosition, 0, 0);
                    }
                }
            }
        }
    }
}
