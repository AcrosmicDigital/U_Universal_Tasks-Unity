using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace U.Universal.Tasks
{ 
    public static class AsyncOperationExtension
    {


        public static async Task WaitAsTask(this AsyncOperation asyncOperation)
        {
            if (Application.isPlaying)
            {
                IEnumerator Helper()
                {
                    while (!asyncOperation.isDone)
                        yield return null;
                }

                var host = new GameObject("AsyncOperation-Host");
                UnityEngine.Object.DontDestroyOnLoad(host);
                try
                {
                    await Helper().WaitAsTask(host);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    UnityEngine.Object.Destroy(host);
                }

                return;
                
            }

            // The Task that will wait for the coroutine
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            asyncOperation.completed += (o) => tcs.SetResult(true);

            await tcs.Task;

        }

        
    }
}
