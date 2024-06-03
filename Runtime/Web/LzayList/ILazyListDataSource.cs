using System;
using System.Collections.Generic;

namespace QuickWeb.Web.LazyList {
    public interface ILazyListDataSource<T> where T : IListElement {
        int Count { get; }
        int LastPage {get;}
        List<T> Elements { get; }
        public void LoadNextPage();
        public T GetElement(int index);
        public void SetElement(int index, T element);
        public void AddElement(T element);
        public void RemoveElement(T element);
        public void RemoveElementAt(int index);
        /// <summary>
        /// Invoked when already loaded data is altered.
        /// </summary>
        /// <value> altered list </value>
        public Action<List<T>> OnDataChanged { get; set; }
        /// <summary>
        /// Invoked when new data is loaded to the list 
        /// </summary>
        /// <value>new loaded data</value>
        public Action<List<T>> OnDataAdded {get; set;}
        public void Clear();
    }
}
