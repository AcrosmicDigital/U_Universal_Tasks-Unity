using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


namespace U.Universal.Tasks
{

    public static class TaskExtension
    {

        public static async void Then(this Task task, Action<Exception> Reject = null, Action Resolve = null, Action Finally = null)
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

        public static async void Then<TResult>(this Task<TResult> task, Action<Exception> Reject = null, Action<TResult> Resolve = null, Action Finally = null)
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


    }


}
