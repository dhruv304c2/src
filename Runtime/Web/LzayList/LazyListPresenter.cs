using System.Collections.Generic;
using QuickWeb.ObjectPool;
using UnityEngine;

namespace QuickWeb.Web.LazyList {
    public class LazyListPresenter: MonoBehaviour {
        [Header("Element pool setting")]
        [SerializeField] ListElementPresenter listElementPrefab;
        [SerializeField] int listElementPoolSize;
        [SerializeField] ColumnText columnTextPrefab;
        [SerializeField] int columnTextPoolSize = 100;

        [Header("Content setting")]
        [SerializeField] Transform content;

        private MonoObjectPool<ListElementPresenter> _listElementPool = new();
        private MonoObjectPool<ColumnText> _columnTextPool = new();
        
        private void Awake() {
            _listElementPool.Initialise(listElementPoolSize, listElementPrefab);
            _columnTextPool.Initialise(columnTextPoolSize, columnTextPrefab);
        }

        public void LoadPage<T>(List<T> listElements) 
        where T : IListElement {
            foreach (var listElement in listElements) {
                var element = CreateListElement(); 
                element.transform.SetParent(content);
                element.RenderListElement(listElement);
            }
        }

        public ListElementPresenter CreateListElement() {
            var element =  _listElementPool.Spawn();
            element.Construct(_columnTextPool);
            return element;
        }    
    }
}