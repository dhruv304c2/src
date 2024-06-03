using System.Collections.Generic;
using QuickWeb.ObjectPool;
using UnityEngine;

namespace QuickWeb.Web.LazyList {
    public class LazyListPresenter: MonoBehaviour {
        [Header("Element pool setting")]
        [SerializeField] ListElementPresenter listElementPrefab;
        [SerializeField] int listElementPoolSize;

        [Header("Content setting")]
        [SerializeField] Transform content;

        private MonoObjectPool<ListElementPresenter> _listElementPool = new();
        
        private void Awake() {
            _listElementPool.Initialise(listElementPoolSize, listElementPrefab);
        }

        public void LoadPage<T>(List<T> listElements) 
        where T : IListElement {
            foreach (var listElement in listElements) {
                var element = _listElementPool.Spawn();
                element.transform.SetParent(content);
                element.RenderListElement(listElement);
            }
        }    
    }
}