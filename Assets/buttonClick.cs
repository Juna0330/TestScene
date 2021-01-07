using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Transition
{
    public class buttonClick : MonoBehaviour
    {
        public void SceneClick()
        {
            SceneLoader.LoadScene(Model.GameScenes.title);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
