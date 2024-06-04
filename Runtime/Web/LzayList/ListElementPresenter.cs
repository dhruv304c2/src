using QuickWeb.ObjectPool;
using TMPro;
using UnityEngine;

namespace QuickWeb.Web.LazyList {
    public class ListElementPresenter : MonoPoolableObject<ListElementPresenter>{
        [SerializeField] private RectTransform content;
        private IObjectPool<ColumnText> _columnTextPool;

        public void Construct(IObjectPool<ColumnText> columnTextPool) {
            _columnTextPool = columnTextPool;
        }

        public override void OnDespawn() {
        }

        public override void OnSpawn() {
        }

        public void RenderListElement<T>(T listElement) 
        where T : IListElement {
        }
    }
}
