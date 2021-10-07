using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace U.Universal.Tasks
{
    public class UroutineRunner : MonoBehaviour
    {

        public UnityEvent OnDestroyEvent = new UnityEvent();

        private void OnDestroy()
        {
            OnDestroyEvent?.Invoke();
        }

    }

}
