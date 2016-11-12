using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexInfoModels;

namespace Data_Service.Info_Flex.Repositories
{
    public class CustomerRepository
    {
        public List<KUNDER> Get()
        {
            using (var context = new InfoFlexEntities())
            {
                return context.KUNDER.ToList();
            }
        }

        public KUNDER Get(string customerNo)
        {
            using (var context = new InfoFlexEntities())
            {
                return context.KUNDER.FirstOrDefault(x => x.KUNDNR == customerNo);
            }
        }
    }
}
