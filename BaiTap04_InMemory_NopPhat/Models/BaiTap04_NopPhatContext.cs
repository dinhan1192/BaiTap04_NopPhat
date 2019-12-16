using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaiTap04_InMemory_NopPhat.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BaiTap04_NopPhatContext : DbContext
    {
        public BaiTap04_NopPhatContext() : base("name=MySQLContext")
        {

        }
     
        public System.Data.Entity.DbSet<BaiTap04_InMemory_NopPhat.Models.PunishFiled> PunishFileds { get; set; }
    }
}