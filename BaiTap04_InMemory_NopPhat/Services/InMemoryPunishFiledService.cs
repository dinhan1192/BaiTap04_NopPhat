using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaiTap04_InMemory_NopPhat.Models;

namespace BaiTap04_InMemory_NopPhat.Services
{
    public class InMemoryPunishFiledService : IPunishFiledService
    {
        private static List<PunishFiled> _listPunishFiled;
        private decimal _totalMoneyPunished;
        private int _totalPush;

        public InMemoryPunishFiledService()
        {
            if (_listPunishFiled == null)
            {
                _listPunishFiled = new List<PunishFiled>();
            }
        }

        public decimal GetTotalMoneyPunished()
        {
            this._totalMoneyPunished = 0;
            if(_listPunishFiled == null || _listPunishFiled.Count == 0)
            {
                return 0;
            }
            foreach (var item in _listPunishFiled)
            {
                if(item.PunishTypeId == PunishFiled.PunishType.MoneyFiled)
                {
                    this._totalMoneyPunished += item.AmountOfPunished;
                }
            }
            return this._totalMoneyPunished;
        }

        public int GetTotalPushPunished()
        {
            this._totalPush = 0;
            if (_listPunishFiled == null || _listPunishFiled.Count == 0)
            {
                return 0;
            }
            foreach (var item in _listPunishFiled)
            {
                if (item.PunishTypeId == PunishFiled.PunishType.Push)
                {
                    this._totalPush += (int)item.AmountOfPunished;
                }
            }
            return this._totalPush;
        }

        public List<PunishFiled> GetList()
        {
            return _listPunishFiled;
        }

        public PunishFiled Store(PunishFiled punishFiled)
        {
            punishFiled.Id = _listPunishFiled.Count + 1;
            _listPunishFiled.Add(punishFiled);
            return punishFiled;
        }
    }
}