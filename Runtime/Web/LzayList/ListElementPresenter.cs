using QuickWeb.ObjectPool;

namespace QuickWeb.Web.LazyList {
    public class ListElementPresenter : MonoPoolableObject<ListElementPresenter>{
        public override void OnDespawn() {
        }

        public override void OnSpawn() {
        }

        public void RenderListElement<T>(T listElement) 
        where T : IListElement {
        }
    }
}
