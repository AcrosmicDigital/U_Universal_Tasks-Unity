using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using UnityEngine;

namespace U.Universal.Tasks
{

    public static class TaskExtension
    {

        public static async void Then(this Task task, Action<Exception> Reject, Action Resolve, Action Finally)
        {
            
            try
            {
                await task;
                Resolve?.Invoke();
            }
            catch (Exception e)
            {
                Reject?.Invoke(e);
            }
            finally
            {
                Finally?.Invoke();
            }
        }

        public static async void Then<TResult>(this Task<TResult> task, Action<Exception> Reject, Action<TResult> Resolve, Action Finally)
        {

            try
            {
                TResult result = await task;
                Resolve?.Invoke(result);
            }
            catch (Exception e)
            {
                Reject?.Invoke(e);
            }
            finally
            {
                Finally?.Invoke();
            }

        }

        public static IEnumerator WaitAsCorroutine(this Task task)
        {

            while (!task.IsCompleted)
                yield return null;

            if (task.IsFaulted)
                throw task.Exception;

        }





        public static void Resolve(this Task task, Action Resolve) => task.Then((e) => { }, Resolve, () => { });
        public static void Resolve<TResult>(this Task<TResult> task, Action<TResult> Resolve) => task.Then<TResult>((e) => { }, Resolve, () => { });
        public static void Reject(this Task task, Action<Exception> Reject) => task.Then(Reject, () => { }, () => { });
        public static void Reject<TResult>(this Task<TResult> task, Action<Exception> Reject) => task.Then<TResult>(Reject, (r) => { }, () => { });
        public static void RejectPrintError(this Task task) => task.Then((e) => Debug.Log(e), () => { }, () => { });
        public static void RejectPrintError<TResult>(this Task<TResult> task) => task.Then<TResult>((e) => Debug.Log(e), (r) => { }, () => { });
        public static void Finally(this Task task, Action Finally) => task.Then((e) => { }, () => { }, Finally);
        public static void Finally<TResult>(this Task<TResult> task, Action Finally) => task.Then<TResult>((e) => { }, (r) => { }, Finally);


    }


}
