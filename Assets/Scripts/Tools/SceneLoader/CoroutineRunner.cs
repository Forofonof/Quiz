using System.Collections;
using UnityEngine;

namespace Tools.SceneLoader
{
    public sealed class CoroutineRunner : MonoBehaviour
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}