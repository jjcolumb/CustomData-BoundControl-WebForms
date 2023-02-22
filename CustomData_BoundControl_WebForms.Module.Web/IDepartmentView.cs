using CustomData_BoundControl_WebForms.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomData_BoundControl_WebForms.Module.Web
{
    public interface IDepartmentView
    {
        string Title { get; set; }
        ICollection<Contact> Contacts { get; set; }
        event EventHandler TitleChanged;
    }
}
