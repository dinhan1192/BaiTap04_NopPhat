using BaiTap04_InMemory_NopPhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap04_InMemory_NopPhat.Services
{
    interface IPunishFiledService
    {
        PunishFiled Store(PunishFiled punishFiled);
        List<PunishFiled> GetList();
        decimal GetTotalMoneyPunished();
        int GetTotalPushPunished();
    }
}
