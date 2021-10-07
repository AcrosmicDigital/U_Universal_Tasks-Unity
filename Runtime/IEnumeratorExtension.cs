using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;


namespace U.Universal.Tasks
{

    public static class IEnumeratorExtension
    {

       /// <summary>
       /// This function allows you to catch exceptions from an IEnumerator
       /// </summary>
       /// <param name="iEnumerator"> The IEnumerator that throw exception</param>
       /// <param name="Reject"> Optional callback with the exception throwed </param>
       /// <returns></returns>
        public static IEnumerator Catch(this IEnumerator iEnumerator, Action<Exception> Reject = null)
        {
            object current;
            // Corre el enumerator hijo y captura la excepcion

            while (true)
            {
                try
                {
                    if (!iEnumerator.MoveNext())
                        break;
                    current = iEnumerator.Current;
                }
                catch (Exception e)
                {
                    Reject?.Invoke(e);
                    yield break;
                }
                yield return current;
            }
            // Regresa el enumerator capturado o null si da excepcion y corre el Reject

            yield return null;
        }

        public async static Task WaitAsTask(this IEnumerator iEnumerator, GameObject gameObject)
        {

            // The Task that will wait for the coroutine
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            // Exception catched from the IEnumerator
            Exception error = null;

            // Current object returned for the corroutine
            object current;


            // The IEnumerator that will help to wait for the corroutine
            IEnumerator Helper()
            {

                while (true)
                {
                    try
                    {
                        if (!iEnumerator.MoveNext())
                            break;
                        current = iEnumerator.Current;
                    }
                    catch (Exception e)
                    {
                        error = e;
                        break;
                    }

                    yield return current;
                }

                // If exceptions
                if (error != null)
                    tcs.SetException(error);
                else
                {
                    tcs.SetResult(true);
                }

                yield break;
            }


            // Is searched a monobehavior to run the coroutines
            UroutineRunner uroutineRunner = gameObject.GetComponent<UroutineRunner>();
            // Is added the MonoBehaviour to the GameObject if there is no one
            if(uroutineRunner == null) 
                uroutineRunner = gameObject.AddComponent<UroutineRunner>();

            // Subscription to the listener
            uroutineRunner.OnDestroyEvent.AddListener(() =>
            {

                try
                {
                    if (!tcs.Task.IsCompleted)
                    {
                        error = new GameObjectDestroyedBeforeUroutineEndException();
                        tcs.SetException(error);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }

            });

            // The coroutine is started and the Task is returned
            uroutineRunner.StartCoroutine(Helper());
            await tcs.Task;

        }

        public async static Task<TResult> WaitAsTask<TResult>(this IEnumerator iEnumerator, GameObject gameObject)
        {

            // The Task that will wait for the coroutine
            TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();

            // Exception catched from the IEnumerator
            Exception error = null;

            // Current object returned for the corroutine
            object current = null;

            // Value of the result
            TResult result;


            // The IEnumerator that will help to wait for the corroutine
            IEnumerator Helper()
            {

                while (true)
                {
                    try
                    {
                        if (!iEnumerator.MoveNext())
                            break;
                        current = iEnumerator.Current;
                    }
                    catch (Exception e)
                    {
                        error = e;
                        result = default(TResult);
                        break;
                    }

                    yield return current;
                }

                // If exceptions
                if (error != null)
                {
                    tcs.SetException(error);
                    yield break;
                }
                else
                {
                    try
                    {
                        result = (TResult)current;
                        tcs.SetResult(result);
                    }
                    catch (Exception e)
                    {

                        error = new InvalidCastException("Returned value from corutine cant be cast to type TResult", e);
                        tcs.SetException(error);
                    }

                }

            }


            // Is searched a monobehavior to run the coroutines
            UroutineRunner uroutineRunner = gameObject.GetComponent<UroutineRunner>();
            // Is added the MonoBehaviour to the GameObject if there is no one
            if (uroutineRunner == null)
                uroutineRunner = gameObject.AddComponent<UroutineRunner>();

            // Subscription to the listener
            uroutineRunner.OnDestroyEvent.AddListener(() =>
            {

                try
                {
                    if (!tcs.Task.IsCompleted)
                    {
                        error = new GameObjectDestroyedBeforeUroutineEndException();
                        tcs.SetException(error);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }

            });


            // The coroutine is started and the Task is returned
            uroutineRunner.StartCoroutine(Helper());
            return await tcs.Task;

        }


    }

}