/**
Matches the rotation of the transform this script is on with an external transform.

Intended for use with Neck transforms on avatars that are driven by a VR headset.

Author: Ivan Bindoff
*/

using UnityEngine;
using System.Collections;

namespace LeapAvatarHands
{

    public class MatchRotation : MonoBehaviour
    {
        public Transform targetTransform;   //i.e. the camera being driven by a VR headset
        
        void LateUpdate()
        {
            if (targetTransform != null)
                transform.rotation = targetTransform.rotation;
        }
    }
}
