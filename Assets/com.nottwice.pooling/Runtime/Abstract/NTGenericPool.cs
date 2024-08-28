using NaughtyAttributes;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.Serializables.Abstract;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace NotTwice.Pooling.Runtime.Abstract
{
    /// <summary>
    /// Base class for a pool that optimises memory usage when creating/retrieving object instances.
    /// </summary>
    public abstract class NTGenericPool<T, U> : ScriptableObject, IObjectPool<U>
        where T : NTGenericGameEvent<T, U>
        where U : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Defines whether a factory is used instead of a simple duplication from a prefab.
        /// </summary>
        [Tooltip("Defines whether a factory is used instead of a simple duplication from a prefab.")]
        public bool Usefactory;

        /// <summary>
        /// Prefab used to create the pool elements
        /// </summary>
        [Tooltip("Prefab used to create the pool elements")]
        [Required]
        [ShowIf(nameof(_dontUseFactory))]
        public U Prefab;

        /// <summary>
        /// Prefab used to create the pool elements
        /// </summary>
        [Tooltip("Prefab used to create the pool elements")]
        [Required]
        [ShowIf(nameof(Usefactory))]
        public NTGenericFactory<U> Factory;

        /// <summary>
        /// Name of the object that will be created to store the elements in the pool
        /// </summary>
        [Tooltip("Name of the object that will be created to store the elements in the pool")]
        [InfoBox("Default name is {nameof(U)}Pool")]
        public string PoolName;

        /// <summary>
        /// Initial size of the pool, at initialisation, as many instances will be created
        /// </summary>
        [Tooltip("Initial size of the pool, at initialisation, as many instances will be created")]
        public int InitialSize = 10;

        /// <summary>
        /// Event triggered when an item is retrieved from the pool
        /// </summary>
        [Tooltip("Event triggered when an item is retrieved from the pool")]
        public NTGenericEventTypeSwitcher<T, U> OnGet;

        /// <summary>
        /// Event triggered when an item in the pool is returned
        /// </summary>
        [Tooltip("Event triggered when an item in the pool is returned")]
        public NTGenericEventTypeSwitcher<T, U> OnRelease;

        /// <summary>
        /// Event triggered when an element in the pool is destroyed
        /// </summary>
        [Tooltip("Event triggered when an element in the pool is destroyed")]
        public NTGenericEventTypeSwitcher<T, U> OnDestroy;

        #endregion

        #region Properties

        private Stack<U> _inQueue;

        private GameObject _goPoolContainer;

        private bool _dontUseFactory
        {
            get
            {
                return !Usefactory;
            }
        }

        private string _defaultPoolName = $"{nameof(U)}Pool";

        #endregion

        #region Unity Messages

        protected virtual void OnEnable()
        {
            _inQueue = new Stack<U>();
        }

        protected virtual void OnDisable()
        {
            Clear();
        }

        #endregion

        public int CountInactive
        {
            get
            {
                return _inQueue.Count;
            }
        }

        /// <summary>
        /// Method used to clear the pool.
        /// </summary>
        public void Clear()
        {
            while (_inQueue.Count > 0)
            {
                U item = _inQueue.Pop();
                OnDestroy?.Raise(item);

                if (item != null)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        /// <summary>
        /// Method used to get an element from the pool and trigger the callback <see cref="OnGet"/>.
        /// </summary>
        public U Get()
        {
            U item;
            if (_inQueue.Count > 0)
            {
                item = _inQueue.Pop();
            }
            else
            {
                item = Usefactory ? Factory.Create() : Instantiate(Prefab);
            }

            item.gameObject.SetActive(true);
            OnGet?.Raise(item);
            return item;
        }

        /// <summary>
        /// Method whose implementation is necessary but which must not be used. In the context of a scriptable object, the <see cref="PooledObject"/> returned is empty.
        /// </summary>
        public PooledObject<U> Get(out U item)
        {
            item = Get();
            return new PooledObject<U>();
        }

        /// <summary>
        /// Method used to restore an element to the pool and trigger the callback <see cref="OnRelease"/>.
        /// </summary>
        public void Release(U element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "Cannot release a null element to the pool.");
            }

            element.gameObject.SetActive(false);
            element.transform.SetParent(_goPoolContainer.transform);

            OnRelease?.Raise(element);
            _inQueue.Push(element);
        }

        /// <summary>
        /// Method used to initialise the pool and create the various clones that will make it up
        /// </summary>
        public void InitializePool()
        {
            if(Usefactory && Factory == null)
            {
                throw new MissingComponentException("The factory is missing when it is supposed to be used");
            }

            _goPoolContainer = new GameObject(string.IsNullOrEmpty(PoolName) ? _defaultPoolName : PoolName);

            // Pre-fill the pool with inactive instances
            for (int i = 0; i < InitialSize; i++)
            {
                U item = Usefactory ? Factory.Create() : Instantiate(Prefab);
                item.gameObject.SetActive(false);

                item.transform.SetParent(_goPoolContainer.transform);

                _inQueue.Push(item);
            }
        }
    }
}