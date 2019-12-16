using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTap04_InMemory_NopPhat.Models
{
    public class PunishFiled
    {
        public int? Id { get; set; }
        public string RollNumber { get; set; }
        [Display(Name = "Punish Type")]
        public PunishType PunishTypeId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal AmountOfPunished { get; set; }
        public DateTime DateOfPunishFiled { get; set; }

        public enum PunishType { Push = 1, MoneyFiled = 2 }

        public PunishFiled()
        {
            DateOfPunishFiled = DateTime.Now;
        }
    }
}