using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexInfoModels;


namespace Data_Service.Info_Flex.Repositories
{
    public class WasteRepository
    {
        public List<ARTIKLAR> Get()
        {
            using (var context = new InfoFlexEntities())
            {
                return context.ARTIKLAR.Where(x => x.KLASS == "90").ToList();
            }
        }

        public ARTIKLAR Get(string artNo)
        {
            using (var context = new InfoFlexEntities())
            {
                var waste =  context.ARTIKLAR.FirstOrDefault(x => x.ARTNR == artNo);
                return waste;
            }
        }
    }
}
