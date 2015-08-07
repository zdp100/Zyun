using OSharp.Core.Data.Entity;
using OSharp.Demo.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Demo.ModelConfigurations.Identity
{
    public class UserAddressConfiguration :ComplexTypeConfigurationBase<UserAddress,Int32>
    {
        public UserAddressConfiguration()
        {
            Property(m => m.Province).HasColumnName("Province");
            Property(m => m.City).HasColumnName("City");
            Property(m => m.County).HasColumnName("County");
            Property(m => m.Street).HasColumnName("Street");

        }
    }
}
