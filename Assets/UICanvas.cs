using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transition
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] Fade fade;
        [SerializeField] FadeImage image;
        public Fade Fade { get { return fade; } }
        public FadeImage FadeImage { get { return image; } }
    }
}
