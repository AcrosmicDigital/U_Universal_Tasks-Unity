using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace U.Universal.Tasks
{
    public static partial class UnityTask
    {

        public static async Task WaitForSeconds(GameObject gameObject, float seconds)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitForSeconds(seconds);
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task WaitForSecondsRealtime(GameObject gameObject, float time)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitForSecondsRealtime(time);
            }

            await Helper().WaitAsTask(gameObject);

        }






        public static async Task WaitForEndOfFrame(GameObject gameObject)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitForEndOfFrame();
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task WaitForFixedUpdate(GameObject gameObject)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitForFixedUpdate();
            }

            await Helper().WaitAsTask(gameObject);

        }

        /// <summary>
        /// Wait while predicate is false, when is true the wait will rnd
        /// </summary>
        /// <param name="predicate">condition to wait</param>
        /// <returns></returns>
        public static async Task WaitUntil(GameObject gameObject, Func<bool> predicate)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitUntil(predicate);
            }

            await Helper().WaitAsTask(gameObject);

        }

        /// <summary>
        /// Wait while the predicate is true, when predicate is false, wait will end
        /// </summary>
        /// <param name="predicate">Condition to wait</param>
        /// <returns></returns>
        public static async Task WaitWhile(GameObject gameObject, Func<bool> predicate)
        {
            
            IEnumerator Helper()
            {
                yield return new WaitWhile(predicate);
            }

            await Helper().WaitAsTask(gameObject);

        }





        public static async Task RunWhile(GameObject gameObject, Func<bool> predicate, Action action)
        {
            
            IEnumerator Helper()
            {
                bool condition = true;

                while (condition)
                {
                    condition = predicate();
                    action?.Invoke();

                    yield return null;
                }

            }

            await Helper().WaitAsTask(gameObject);
        }


        public static async Task RunUntil(GameObject gameObject, Func<bool> predicate, Action action)
        {
            
            IEnumerator Helper()
            {
                bool condition = false;

                while (!condition)
                {
                    condition = predicate();
                    action?.Invoke();

                    yield return null;
                }

            }

            await Helper().WaitAsTask(gameObject);
        }


        /// <summary>
        /// Execute the action every frame for specified time, if game is paused time still count
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task RunForSecondsRealTime(GameObject gameObject, float seconds, Action action)
        {
            
            IEnumerator Helper()
            {
                while (seconds > 0)
                {
                    seconds -= Time.unscaledDeltaTime;

                    try
                    {
                        action?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.ExecuteForSeconds: Error in action delegate, " + e);
                    }

                    yield return null;
                }

            }

            await Helper().WaitAsTask(gameObject);

        }

        /// <summary>
        /// Execute the action every frame for specified time, if game is paused time dont count, but delegate will still executing
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task RunForSeconds(GameObject gameObject, float seconds, Action action)
        {
            
            IEnumerator Helper()
            {
                while (seconds > 0)
                {
                    seconds -= Time.deltaTime;

                    try
                    {
                        action?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.ExecuteForSeconds: Error in action delegate, " + e);
                    }

                    yield return null;
                }

            }

            await Helper().WaitAsTask(gameObject);

        }



        public static async Task SendWebRequest(GameObject gameObject, UnityWebRequest unityWebRequest)
        {
            
            IEnumerator Helper()
            {
                yield return unityWebRequest.SendWebRequest();
            }

            await Helper().WaitAsTask(gameObject);

        }



        public static async Task LoadSceneAsync(GameObject gameObject, int sceneBuildIndex, LoadSceneMode mode, Action<float> whileLoad = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileLoad?.Invoke(Mathf.Clamp01(loadOperation.progress / .9f));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task LoadSceneAsync(GameObject gameObject, string sceneName, LoadSceneMode mode, Action<float> whileLoad = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, mode);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileLoad?.Invoke(Mathf.Clamp01(loadOperation.progress / .9f));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task UnloadSceneAsync(GameObject gameObject, int sceneBuildIndex, Action whileUnload = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.UnloadSceneAsync(sceneBuildIndex);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileUnload?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task UnloadSceneAsync(GameObject gameObject, string sceneName, Action whileUnload = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.UnloadSceneAsync(sceneName);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileUnload?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

    }
}
