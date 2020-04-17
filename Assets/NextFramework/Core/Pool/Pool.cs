/**
#########################
#
# Author:uniu
# Date:4/16/2020 7:40:21 PM
#
#########################
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextFramework
{
    public interface IPool<T>
    {
        T GetItem();
        bool Recycle(T obj);
    }
    public interface IObjectFactory<T>
    {
        T Create();
    }

    public abstract class Pool<T> : IPool<T>
    {
        protected Queue<T> mObjectPool = new Queue<T>();
        protected IObjectFactory<T> mFactory;

        public int Count
        {
            get { return mObjectPool.Count; }
        }
        public T GetItem()
        {
            return mObjectPool.Count > 0 ? mObjectPool.Dequeue() : mFactory.Create();
        }

        public bool Recycle(T obj)
        {
            throw new System.NotImplementedException();
        }
    }

    public class NObjectPool<T> : Pool<T>
    {
    }
}

