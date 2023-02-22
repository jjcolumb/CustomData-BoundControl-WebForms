using CustomData_BoundControl_WebForms.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomData_BoundControl_WebForms.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DepartmentViewController : ObjectViewController<DetailView, Department>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public DepartmentViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            foreach (WebCustomUserControlViewItem item in View.GetItems<WebCustomUserControlViewItem>())
            {
                item.ControlCreated += ViewItem_ControlCreated;
            }
            View.CurrentObjectChanged += View_CurrentObjectChanged;
        }

        private void View_CurrentObjectChanged(object sender, EventArgs e)
        {
            foreach (WebCustomUserControlViewItem item in View.GetItems<WebCustomUserControlViewItem>())
            {
                IDepartmentView departmentView = item.Control as IDepartmentView;
                if (departmentView != null)
                {
                    InitializeDepartmentView(departmentView);
                }
            }
        }

        private void ViewItem_ControlCreated(object sender, EventArgs e)
        {
            IDepartmentView departmentView = ((WebCustomUserControlViewItem)sender).Control as IDepartmentView;
            if (departmentView != null)
            {
                departmentView.TitleChanged += DepartmentView_TitleChanged;
                InitializeDepartmentView(departmentView);
            }
        }

        private void DepartmentView_TitleChanged(object sender, EventArgs e)
        {
            if (ViewCurrentObject != null)
            {
                ViewCurrentObject.Title = ((IDepartmentView)sender).Title;
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        private void InitializeDepartmentView(IDepartmentView departmentView)
        {
            if (ViewCurrentObject != null)
            {
                departmentView.Title = ViewCurrentObject.Title;
                departmentView.Contacts = ViewCurrentObject.Contacts;
            }
            else
            {
                departmentView.Title = null;
                departmentView.Contacts = null;
            }
        }



        protected override void OnDeactivated()
        {
            foreach (WebCustomUserControlViewItem item in View.GetItems<WebCustomUserControlViewItem>())
            {
                item.ControlCreated -= ViewItem_ControlCreated;
            }
            View.CurrentObjectChanged -= View_CurrentObjectChanged;
            base.OnDeactivated();
        }
    }
}
