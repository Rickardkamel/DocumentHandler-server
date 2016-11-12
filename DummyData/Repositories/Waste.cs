//using Contracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DummyData.Repositories
//{
//    public class Waste
//    {
//        private List<WasteContract> _wasteDummyList;

//        public Waste()
//        {
//            _wasteDummyList = GetDummyData();
//        }

//        private List<WasteContract> GetDummyData()
//        {
//            var dummyWasteList = new List<WasteContract>
//            {
//                new WasteContract
//                {
//                    Id = "702-4",
//                    Text = "AEROSOLER AVFALL",
//                    EuropeanWasteCatalogueCode = "EWC 200127",
//                    UnTextGroup = "UN 1950 AEROSOLER, brandfarliga, (D), 2.1, ",
//                    Class = "",
//                    PackagingGroup = ""
//                },
//                new WasteContract
//                {
//                    Id = "702-28",
//                    Text = "AIRBAGS",
//                    EuropeanWasteCatalogueCode = "EWC 160110",
//                    Declaration = "UN 3268 GASGENERATORER FÖR KROCKKUDDAR, (E)",
//                    Class = "9",
//                    PackagingGroup = "|||"
//                }
//            };
//            return dummyWasteList;
//        }

//        public List<WasteContract> Get()
//        {
//            return _wasteDummyList;
//        }

//        public WasteContract Get(string id)
//        {
//            var dummyCustomer = _wasteDummyList.FirstOrDefault(x => x.Id == id);

//            if (dummyCustomer == null) return null;

//            return dummyCustomer;
//        }
//    }
//}
