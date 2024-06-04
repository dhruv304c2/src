using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace QuickWeb.Web.LazyList{
    public abstract class BaseLazyListDataSource<T> : MonoBehaviour, ILazyListDataSource<T>
    where T : IListElement {
        public List<T> Elements { get; private set; } = new();
        public int Count => Elements.Count; 
        public int LastPage {get; private set;} = 0;
        public Action<List<T>> OnDataChanged { get; set; }
        public Action<List<T>> OnDataAdded { get; set; }
        
        [SerializeField] private LazyListPresenter _lazyListPresenter;        
        
        void Awake() {
            OnDataAdded += _lazyListPresenter.LoadPage;
        }

        public void AddElement(T element){
            Elements.Add(element);
            OnDataChanged?.Invoke(Elements);
        }

        public void Clear() {
            Elements.Clear();
            OnDataChanged?.Invoke(Elements);
        }

        public T GetElement(int index) {
            return Elements[index];
        } 

        public void RemoveElement(T element) {
            Elements.Remove(element);
            OnDataChanged?.Invoke(Elements);
        }

        public void RemoveElementAt(int index) {
            Elements.RemoveAt(index);
            OnDataChanged?.Invoke(Elements);
        }

        public void SetElement(int index, T element) {
            Elements[index] = element;
            OnDataChanged?.Invoke(Elements);
        }

        /// <summary>
        /// Implement this method to load a page of elements.
        /// return null or empty list if there are no more elements to load. 
        /// </summary> 
        /// <param name="page"> index of page to be loaded</param>
        /// <returns> list on elements on page</returns>
        public abstract List<T> LoadPage(int page);

        [Button("Load Next Page")]
        public void LoadNextPage(){
            var page = LastPage + 1;
            var elements = LoadPage(page);
            if(elements == null || elements.Count == 0) return;
            foreach (var element in elements) {
                Elements.Add((T)element);
            }
            LastPage++;
            OnDataAdded?.Invoke(elements);
        } 
    }
}
