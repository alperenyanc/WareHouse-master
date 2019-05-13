using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Model.Enum;
using WareHouse.Model.Interface;

namespace WareHouse.Model.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }

        private DateTime _updateDate = DateTime.Now;
        public DateTime UpdateDate { get { return _updateDate; } set { _updateDate = value; } }

        private DateTime _deletedDate = DateTime.Now;
        public DateTime DeleteDate { get { return _deletedDate; } set { _deletedDate = value; } }

        private Status _status = WareHouse.Model.Enum.Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
