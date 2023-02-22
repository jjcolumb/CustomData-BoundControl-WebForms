using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomData_BoundControl_WebForms.Module.BusinessObjects;
using CustomData_BoundControl_WebForms.Module.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;

namespace CustomData_BoundControl_WebForms.Web
{
    public partial class DepartmentViewControl : UserControl, IDepartmentView, IComplexControl
    {
        private bool isInitialized;
        private string _Title;
        private ICollection<Contact> _Contacts;
        private IObjectSpace ObjectSpace;
        

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                UpdateTitleControl();
            }
        }
        public ICollection<Contact> Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                UpdateContactsControl();
            }
        }
        public event EventHandler TitleChanged;

        protected override void OnInit(EventArgs e)
        {
            isInitialized = true;
            UpdateTitleControl();
            UpdateContactsControl();
            TitleControl.TextChanged += TitleControl_TextChanged;
            base.OnInit(e);
        }
        private void UpdateTitleControl()
        {
            if (!isInitialized) return;
            TitleControl.Text = Title;
        }
        private void UpdateContactsControl()
        {
            if (!isInitialized) return;
            ContactsControl.DataSource = Contacts;
            ContactsControl.DataBind();
        }
        private void TitleControl_TextChanged(object sender, EventArgs e)
        {
            _Title = TitleControl.Text;
            if (TitleChanged != null)
            {
                TitleChanged(this, EventArgs.Empty);
            }
        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            ObjectSpace = objectSpace;
            // TODO: Pass the criteria needed for the Data Source.
            var obj = ObjectSpace.FindObject<Department>(null);
            if (obj != null)
            {
                Title = obj.Title;
                Contacts = obj.Contacts;
            }
            
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}