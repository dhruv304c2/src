using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace QuickWeb.Web.LazyList {
    public class TestLazyDataSource : BaseLazyListDataSource<TestData> { 
        
        public override List<TestData>LoadPage(int page) {
            var newLoadedData = new List<TestData>();
            for (int i = 0; i < 10; i++) {
                newLoadedData.Add(new TestData());
            }
            return newLoadedData;
        }
    }
}

